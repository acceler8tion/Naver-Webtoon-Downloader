## Naver-Webtoon-Downloader
1. [프로그램 개요](#1-프로그램-개요)   
2. [간단한 사용방법](#2-간단한-사용방법)   
　2.1. [최초 다운로드](#21-최초-다운로드)   
　2.2. [업데이트된 회차 다운로드](#22-업데이트된-회차-다운로드)   
　2.2. [삭제된/누락된 파일 다시 다운로드](#23-삭제된누락된-파일-다시-다운로드)    
3. [프로그램 상세](#3-프로그램-상세)   
　3.1. [config.json 설정(기본 다운로드 폴더, 폴더명, 이미지 이름 포맷)](#31-configjson)   
　3.2. [윈도우에서 파일/폴더명으로 사용 불가능한 문자의 처리](#32-윈도우에서-파일폴더명으로-사용-불가능한-문자의-처리)   
4. [릴리즈 정보](#4-릴리즈-정보)   
5. [업데이트 예정 사항](#5-업데이트-예정-사항)  
6. [버그](#6-버그)  
7. [문제 해결하기](#7-문제-해결하기)  

## 1. 프로그램 개요
[다운로드](https://github.com/wr-rainforest/Naver-Webtoon-Downloader/releases/download/v1.1.6.1/Naver-Webtoon-Downloader.v1.1.6.1.zip)   
   
[![GitHub release (latest by date)](https://img.shields.io/github/v/release/wr-rainforest/Naver-Webtoon-Downloader?label=latest&style=flat-square)](https://github.com/wr-rainforest/Naver-Webtoon-Downloader/releases/latest)
[![GitHub All Releases](https://img.shields.io/github/downloads/wr-rainforest/Naver-Webtoon-Downloader/total?label=Downloades&style=flat-square)](https://github.com/wr-rainforest/Naver-Webtoon-Downloader/releases)   
    
c#으로 제작된 웹툰 다운로더입니다.   
한 폴더에 하나의 회차를 저장합니다.    
      
![ㅑㅡ2](/info/Image/v1.0-4.png)
      
          


.Net Frmamework 4.7.2 이상 버전에서 동작합니다.    
윈도우 2018년 4월 업데이트(버전 1803) 이후 버전에서는 런타임 추가 설치 없이도 실행이 가능합니다.     
[.Net Frmamework 4.7.2 다운로드](https://dotnet.microsoft.com/download/dotnet-framework/net472)    
    
    
개발자 연락처 : contact@wrforest.com   
버그 제보, 기타 피드백 주시면 감사하겠습니다.
      
  
      
       
       
## 2. 간단한 사용방법
### 2.1. 최초 다운로드
1. 다운로드 하고자 하는 웹툰을 찾아 해당 웹툰의 url을 확인합니다.  
`예시) 독립일기 url : https://comic.naver.com/webtoon/list.nhn?titleId=748105`  
2. 프로그램을 열고 `download` 커맨드와 함께 url의 `titleId` 값을 입력합니다.  
`예시) download 748105 `    
3. Enter 키를 누르면 다운로드가 시작됩니다.   
  
예시
```
[Command] : download 748105
[2020-09-25 05:01:04] : 1. 독립일기(748105) 대기..

[2020-09-25 05:01:04] : 1. 독립일기(748105) URl 캐시를 생성합니다.
[2020-09-25 05:01:09] : 1. 독립일기(748105) [30/30] (100.00%) [2020.09.23]
[2020-09-25 05:01:09] : 1. 독립일기(748105) URl 캐시를 생성하였습니다..
[2020-09-25 05:01:09] : 1. 독립일기(748105) 다운로드를 시작합니다.
[2020-09-25 05:01:29] : 1. 독립일기(748105) [426/426] (47.49 MB) (100.00%) [2020.09.23]
[2020-09-25 05:01:29] : 1. 독립일기(748105) 다운로드 완료
```

### 2.2. 업데이트된 회차 다운로드
1. 최초 다운로드 방식과 동일하게 명령어를 입력하면 됩니다.   
기본 다운로드 폴더에 존재하는 회차들은 건너뛰고 새롭게 업데이트된 회차만 다운로드합니다.   
    
**주의사항!**   
기본 다운로드 폴더에 존재하지 않는 이미지는 **다운로드 받지 않은 이미지**로 취급합니다.  
   
예시
```
[Command] : download 748105
[2020-09-25 05:26:10] : 1. 독립일기(748105) 대기..

[2020-09-25 05:26:11] : 1. 독립일기(748105) URl 캐시를 불러왔습니다.
[2020-09-25 05:26:11] : 1. 독립일기(748105) 업데이트된 회차를 확인합니다..
[2020-09-25 05:26:11] : 1. 독립일기(748105) URl 캐시를 업데이트합니다.. [no(30) ~ no(30)]
[2020-09-25 05:26:11] : 1. 독립일기(748105) [30/30] (100.00%) [2020.09.23]
[2020-09-25 05:26:11] : 1. 독립일기(748105) URl 캐시에 업데이트된 회차를 추가하였습니다.
[2020-09-25 05:26:11] : 1. 독립일기(748105) 이미 다운로드된 이미지 412장 (46.03 MB)
[2020-09-25 05:26:12] : 1. 독립일기(748105) 다운로드를 시작합니다.
[2020-09-25 05:26:12] : 1. 독립일기(748105) [14/14] (1.45 MB) (100.00%) [2020.09.23]
[2020-09-25 05:26:12] : 1. 독립일기(748105) 다운로드 완료
```
   
### 2.3. 삭제된/누락된 파일 다시 다운로드 
1. 최초 다운로드 방식과 동일하게 명령어를 입력하면 됩니다.   
누락된 파일만 찾아 다운로드합니다.   
    
**주의사항!**   
기본 다운로드 폴더에 존재하지 않는 이미지는 **다운로드 받지 않은 이미지**로 취급합니다.  
   
예시(14장을 삭제하고 다시 다운로드)    
```
[Command] : download 748105
[2020-09-25 06:57:42] : 1. 독립일기(748105) 대기..

[2020-09-25 06:57:42] : 1. 독립일기(748105) URl 캐시를 불러왔습니다.
[2020-09-25 06:57:42] : 1. 독립일기(748105) 업데이트된 회차를 확인합니다..
[2020-09-25 06:57:42] : 1. 독립일기(748105) 업데이트된 회차가 없습니다.
[2020-09-25 06:57:42] : 1. 독립일기(748105) 이미 다운로드된 이미지 412장 (45.87 MB)
[2020-09-25 06:57:42] : 1. 독립일기(748105) 다운로드를 시작합니다.
[2020-09-25 06:57:44] : 1. 독립일기(748105) [14/14] (1.62 MB) (100.00%) [2020.08.26]
[2020-09-25 06:57:44] : 1. 독립일기(748105) 다운로드 완료
```

## 3. 프로그램 상세
### 3.1. config.json  
`/Config/config.json` 파일을 수정하여 설정을 변경할 수 있습니다.   
파일이 삭제되었다면 초기 설정값으로 새로운 파일을 생성합니다. 
  
   
설정값 세부정보    
```
기본 다운로드 폴더 : 실행파일('Naver-Webtoon-Downloader.exe')이 존재하는 폴더 안에 있는 `Download`폴더   
웹툰별 폴더 이름 포맷 : `웹툰 이름`  
회차별 폴더 이름 포맷 : `[업로드 날짜] 회차 제목`  
이미지 파일 이름 포맷 : `[업로드 날짜] 회차 제목 (이미지 번호).jpg`  
   ```   
config.json 파일 내용
``` json
{  
    "DefaultDownloadDirectory": "Download",   
    "WebtoonDirectoryNameFormat": "{1}",  
    "EpisodeDirectoryNameFormat": "[{2}] {4}",    
    "ImageFileNameFormat": "[{5}] {3} - {4} ({2:D3}).jpg"   
} 
```  
  
**수정 주의사항!**  
　DefaultDownloadDirectory의 값에 `\`이 들어간다면 `\`를 4개로 중복해서 써 주어야 합니다.  
```
　예)D드라이브의 image 폴더 아래 Webtoon 폴더를 기본 다운로드 위치로 삼는 경우  
　　 폴더 경로: `D:\image\Webtoon`    
　　 설정값　 : `D:\\\\image\\\\webtoon`  
```
  윈도우에서 파일/폴더명으로 사용 불가능한 문자인 `\` `/` `:` `*` `?` `"` `<` `>` `|` 가 포함 될 수 없습니다  
  `.`(반각 온점)으로 끝나는 값은 사용이 불가능합니다.
  
### 3.2. 윈도우에서 파일/폴더명으로 사용 불가능한 문자의 처리
웹툰 이름, 회차 제목에는 종종 `\` `/` `:` `*` `?` `"` `<` `>` `|`가 포함되어 있는 경우가 있습니다.        
해당 특수문자들은 윈도우에서 파일/폴더명으로 사용이 불가능한 문자들로, 동일한 모양의 전각 문자 `\`　`／`　`：`　`＊`　`？`　`"`　`＜`　`＞`　`｜`로 치환되어 저장됩니다.    
    
만약 회차 제목이 `.`(반각 온점) 으로 끝난다면 해당 온점은 전각 온점으로 치환됩니다.   
윈도우는 파일/폴더명에 온점을 사용할 수 있도록 하지만, 폴더의 마지막의 온점은 모두 잘라냅니다?
  
  
   
## 4. 릴리즈 정보
- __v1.1 (6.1)__
  - 업데이트 내용
    - 다운로드시 마지막 회차를 누락하는 버그를 수정하였습니다.
- __v1.1 (5.2)__
  - 업데이트 내용
    - 새로운 버전을 확인하지 못하는 오류를 수정하였습니다.
- __v1.0 (7571.33791)__
  - 업데이트 내용
    - 한번에 여러개의 titleId 입력이 가능해졌습니다. 다운로드는 순차적으로 이루어집니다.
    - 폴더/파일명에 사용 불가능한 반각 문자(\ / : * ? " < > |)들은 이제부터 동일한 전각 특수문자로 교체됩니다. 
    - 기본 파일명 규칙이 변경되었습니다.
    - 캐시 생성시 비어있는 EpisodeNo를 건너뜁니다. 
    - 업데이트를 자동으로 확인합니다.
    - 콘솔창 폭이 좁을 시 진행상황이 제대로 표시되지 않는 버그를 수정하였습니다.
    - 커맨드 인자 인식 버그를 수정하였습니다.
    - 다운로드 속도가 개선되었습니다.
  - 버그
- __v0.3.0.34414__
  - 특이사항
    - 이번 버전은 하드코딩된 문자열이 많습니다. 추후 제대로 동작하지 않을 가능성이 상당히 높습니다.
  - 업데이트 내용
    - 인터페이스가 대거 수정되었습니다. 커맨드 기반으로 동작합니다.
    - 메인페이지에서 최신 버전 확인이 가능해졌습니다.
    - 웹툰의 titleId 목록을 불러오는 get 커맨드가 추가되었습니다.
  - 버그
    - 스페이스를 두개 이상 붙여서 입력할 시 커맨드 옵션을 인식하지 못합니다.(v1.0)
    - 회차 제목의 끝이 온점이나 스페이스로 끝날 경우 " 경로의 일부를 찾을 수 없습니다." 에러가 발생합니다.(v1.0)
- __v0.2.0-alpha__
  - 업데이트 내용
    - 인터페이스가 추가되었습니다.
    - 입력된 웹툰 titleId가 실제로 서버상에 존재하는지 확인이 가능해졌습니다.
    - 현재 메타데이터 캐시 생성 진행상황을 확인하는 기능이 추가되었습니다.
    - 현재 설정사항을 메인 콘솔창에 보여주는 기능이 추가되었습니다.   
- __v0.1.0-alpha__
  - 업데이트 내용
    - 다운로드 기능만 구현된 초기 버전입니다.   
    - 명령줄 인수로 titleId를 입력받아 동작합니다.
    - 현재 다운로드 진행상황을 볼 수 있습니다.
  - 버그
    - titleId가 존재하지 않을시 `NullReferenceException `을 throw 합니다.  
  
  
   
## 5. 업데이트 예정 사항
* 이미지 병합 기능  
* 다운로드 폴더 설정 기능
  
  
   
## 6. 버그
* 콘솔창 폭이 좁으면 진행률 메세지가 제대로 표시되지 않습니다.
  
  
   
## 7. 문제 해결하기
1. Bad JSON escape sequence
```csharp
처리되지 않은 예외: Newtonsoft.Json.JsonReaderException: Bad JSON escape sequence: 
   위치: Newtonsoft.Json.JsonTextReader.ReadStringIntoBuffer(Char quote)
............................중략............................
   위치: WRforest.NWD.Config..ctor(String json)
   위치: WRforest.NWD.Program.Main(String[] args)
```
원인:Config/config.json 파일에 잘못된 문자가 포함되었습니다.  
해결방법:[3.1.](#31-configjson)  문단의 주의사항에 맞게 config가 설정되어 있는지 확인해주세요.  
설정을 초기화하려면 config.json 파일을 삭제하세요.
