# SVN
> SVN 학습 내용 정리

## Summary

### Subversion 이란?
 - 버전 관리 시스템의 한 종류
 - 서버 + 클라이언트 모델
 - Git과 유사한 소프트웨어

### Subversion 서버
 - 사내 서버에 설치되어 있으며, 주로 사내 인프라 담당자가 관리
 - URL: https://svn.mcnc.co.kr/svn/’ProjectName’ 또는 https://192.168.100.100/svn/’ProjectName’

## 용어

### Repository
 - 파일들이 저장되는 원격 저장소

### Revision
 - 0부터 1씩 증가하는 유일할 값
 - 저장소 내 변경이 발생했을 때마다 증가
 - Merge 등을 할 때 기준이 될 수 있음
 - 가장 최근의 Revision -> HEAD Revision

### Checkout
 - 원격 저장소(Repository)의 파일을 로컬 저장소(Working Copy)로 내려 받음

### Working Copy
 - Repository에서 체크아웃을 통해 내려 받은 개발자 로컬 PC에 있는 복사본

### Add
 - Local 파일을 서브버전이 관리하는 파일로 등록

### Update
 - Local의 파일을 Repository와 비교하여 최신 버전의 상태로 갱신
 - 동일한 파일을 Repository와 Local에서 동시에 변경한 경우 서브버전에서 자동으로 Merge
 - 서브버전에서 Merge를 할 수 없을 경우 Conflict상태로 변경될 수 있음
 - 충돌이 발생하면 사용자에게 Merge 작업을 위임

### Commit
 - Local 파일의 변경을 Repository에 저장
 - 작업이 정상적으로 완료되면 Revision이 증가

### Trunk
 - 운영 중인 안정화된 버전의 소스가 보관되는 디렉터리

### Branches
 - 주로 신규 기능 개발, 실험적인 작업을 위한 소스가 저장되는 디렉터리
 - 보통 작업이 완료되면 trunk 디렉터리로 병합

### Tags
 - 특정 시점의 소스를 보관하기 위해 사용되는 디렉터리
 - 버전 별로 태그를 붙여서 tag 디렉터리 안에 보관
 - 절대 수정하지 않음 (수정이 필요한 경우 branch를 만들어 수정)

### Merge
 - Branch 에서의 작업 내용을 trunk 로 적용하는 작업
 - Branch로 분리된 source에 대해 각각의 변경 내용을 현재의 작업에 병합하고자 할 때 사용

### Lock
 - 두 명 이상의 사용자가 동시에 commit 하지 못하도록 방지

### Conflict
 - Local 파일과 repository 파일 간 충돌(다름)이 발생
 - Ex) 개발자 A가 수정을 하는 도중 개발자 B가 동일한 파일을 수정하여 commit 한 후, 개발자 A가 commit 하게 되면 발생
(개발자 A가 수정을 시작한 revision과 개발자 B가 commit 한 후의 revision이 다름)