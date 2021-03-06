﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WRforest.NWD.DataType;
using WRforest.NWD.Key;

namespace WRforest.NWD.Command
{
    class Merge : Command
    {
        public Merge(Config config) : base(config)
        {
        }

        public override void Start(params string[] args)
        {
            if (args.Length == 0)
            {
                IO.PrintError("titleId를 입력해주세요");
                return;
            }
            if (!int.TryParse(args[0], out _))
            {
                IO.PrintError("titleId는 숫자입니다. : " + args[0]);
                return;
            }
            if (!IO.Exists("Cache", args[0] + ".json"))
            {
                IO.Print($"$$Error : Cache/{args[0]}.json 파일을 찾을 수 없습니다.$red$") ;
                IO.Print("");
                IO.Print($"Merge는 이미 다운로드된 이미지를 합쳐서 새로운 파일로 저장하는 커맨드입니다.");
                IO.Print("");
                IO.Print($"download $${args[0]}$green$ 으로 먼저 이미지를 다운로드 한 후에 merge $${ args[0]}$green$ 를 사용해 주세요.");
                IO.Print("");
                IO.Print($"이미 다운로드된 웹툰임에도 이 메세지가 나타난다면, 캐시파일을 새로 생성해야 합니다.");
                IO.Print("");
                IO.Print($"download $${args[0]}$green$ 로 캐시파일을 생성할 수 있습니다.");
                return;
            }
            var webtoonInfo = JsonConvert.DeserializeObject<WebtoonInfo>(IO.ReadTextFile("Cache", args[0] + ".json"));
            var downloader = new Downloader(webtoonInfo, config);
            int last = webtoonInfo.GetLastEpisodeNo();
            IO.Print(string.Format("{0}($${1}$cyan$) 기본 다운로드 폴더 $${2}$green$ 에서 병합할 파일 확인..", webtoonInfo.WebtoonTitle, args[0],config.DefaultDownloadDirectory), true, true);
            var tuple = downloader.GetDownloadedImagesInformation();
            if(tuple.downloadedImageCount!=webtoonInfo.GetImageCount())
            {
                IO.Print("");
                IO.Print(string.Format("{0}($${1}$cyan$) :누락된 이미지 $${2}$blue$장이 존재합니다. download $${1}$green$ 로 모든 다운로드를 마쳐주세요.  ", webtoonInfo.WebtoonTitle, args[0], webtoonInfo.GetImageCount() - tuple.downloadedImageCount, true, true));
                return;
            }
            IO.Print(string.Format("{0}($${1}$cyan$) 총 $${2}$cyan$장 ($${3:0.00}$blue$ MB) 병합을 시작합니다.  ", webtoonInfo.WebtoonTitle, args[0], tuple.downloadedImageCount, (double)tuple.downloadedImagesSize / 1048576), true, true);
            Thread.Sleep(500);
            FileNameBuilder fileNameBuilder = new FileNameBuilder(webtoonInfo, config);
            var episodeNoList = webtoonInfo.Episodes.Keys.ToArray();
            string webtoonDirectory = config.DefaultDownloadDirectory + "\\" + fileNameBuilder.BuildWebtoonDirectoryName(new WebtoonKey(args[0])) + " - merged";
            if (!Directory.Exists(webtoonDirectory))
            {
                Directory.CreateDirectory(webtoonDirectory);
            }
            else
            {

            }
            for (int i = 0; i < episodeNoList.Length; i++)
            {
                var imageCount = webtoonInfo.Episodes[episodeNoList[i]].EpisodeImageUrls.Length;
                Key.EpisodeKey episodeKey = new Key.EpisodeKey(args[0], episodeNoList[i]);
                string episodeFilePath = webtoonDirectory + "\\" + fileNameBuilder.BuildEpisodeDirectoryName(episodeKey)+".jpg" ;
                if (File.Exists(episodeFilePath))
                {
                    continue;
                }
                if (imageCount==1)
                {
                    File.Copy(fileNameBuilder.BuildImageFileFullPath(new ImageKey(args[0], episodeNoList[i], 0)), episodeFilePath, true) ;
                    continue;
                }
                List<string> webtoonImagePathList = new List<string>();
                for (int j = 0; j < imageCount; j++)
                {
                    webtoonImagePathList.Add(fileNameBuilder.BuildImageFileFullPath(new ImageKey(args[0], episodeNoList[i], j)));
                }
                byte[]buff = MergeImages(webtoonImagePathList);
                File.WriteAllBytes(episodeFilePath, buff);
                progress.Report(string.Format("{0}($${1}$cyan$) [{3}/{4}] ($${5:P}$green$)  $${2}$cyan$장을 병합하였습니다. ", webtoonInfo.WebtoonTitle, args[0], webtoonInfo.Episodes[episodeNoList[i]].EpisodeImageUrls.Length + 1,i+1, episodeNoList.Length,(double)(i+1)/episodeNoList.Length));
                GC.Collect();//
            }
            Thread.Sleep(700);
            Console.WriteLine("");

        }
        private byte[] MergeImages(List<string> imagePathList)
        {
            ImageConverter imageConverter = new ImageConverter();
            List<Bitmap> images = new List<Bitmap>();
            for(int i=0;i< imagePathList.Count;i++)
            {
                images.Add(new Bitmap(imagePathList[i]));
            }
            int maxwidth=0;
            for(int i=0; i<imagePathList.Count;i++)
            {
                if (images[i].Width > maxwidth)
                {
                    maxwidth = images[i].Width;
                }
            }
            int width = maxwidth;
            int height = 0;
            for (int i = 0; i < images.Count; i++)
            {
                height += images[i].Height;
            }
            Bitmap bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            bitmap.SetResolution(images[0].HorizontalResolution, images[0].VerticalResolution);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                height = 0;
                for (int i = 0; i < images.Count; i++)
                {
                    Bitmap image = images[i];
                    image.SetResolution(images[i].HorizontalResolution, images[i].VerticalResolution);

                    if(maxwidth>image.Width)
                    {
                        g.DrawImage(image, (maxwidth - image.Width) / 2, height);
                        height += image.Height;
                        continue;
                    }
                    g.DrawImage(image, 0, height);
                    height += image.Height;
                }
            }
            return (byte[])imageConverter.ConvertTo(bitmap, typeof(byte[]));
        }
    }
}
