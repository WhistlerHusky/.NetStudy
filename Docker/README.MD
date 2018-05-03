# Docker 
Docker 사용법 및 명령어 정리

## docker run hello-world
먼저 hello-world라는 이미지를 local system에서 찾아보고, 없으면 Docker Hub에서 찾아서 다운로드해서 실행함.

## docker ps
활성화되어있는 컨테이너만 보여줌.

## docker ps -a
모든 컨테이너 보여줌

## docker start -attach \<container name\>
local system에있는 컨테이너 이름으로 실행함.

ps -a 하면 하나 (hello-world)만 존재함
여기서 <b>docker run hello-world</b> 한번더 하면 ps -a 하면 2개가 나옴.

## docker stop
실행중인 컨테이너 중지

## docker rm \<container name>
컨테이너 삭제

## docker run -it ubuntu bash
여기서 <b>-it</b> flags는 shell이랑 interact할수있게 하기위한 옵션

## docker top \<container name>
컨테이너 들여다보기.


## docker image ls
local system에 있는 image list 보여줌.
image와 컨테이너는 다름, image는 다운받은거 자체가, 이 image를 가지고 컨테이너를 계속 만들수있음.
e.g. hello-world image 하나로 hello-world 컨테이너를 1개 이상 만들수있음.

# Create a Docker image
Dockerfile 이라는 파일 만들고 아래와 같이 입력
```
FROM nginx
COPY html /usr/share/nginx/html
```
From 은 이미 존재하는 nginx라는 image에서 새로 만드는것.
Copy 명령어는 docker에게 file tree를 base image로 복사해서, /usr/share/nginx/html을 덮어씌워라는 뜻
현재 dockerfile이 있는 폴더 하위폴더에 html폴더가 있어야하고, 이 폴더안에 index.html 파일이 있어야함!

## docker build -t mynginx .
-t mynginx gave Docker a tag for the image. Since we only supplied a name, we can see that Docker tagged this build as the latest in the last line of the build output. We’ll look more closely at tagging below.

The final argument, dot (or “.”), told Docker to look for the Dockerfile in the current working directory.

## docker run --name foo -d -p 8080:80 mynginx
새 이미지 mynginx 실행

--name foo 는 컨테이너 이름을 foo 라고 주는거
-d 는 container에서 떼어서, background로 돌리는거.
-p 논 포트설정

# Share an image

## docker login
로그인

## docker tag mynginx hanuijun/mynginx:1.00
이후에 docker image ls 하면 새로 만들어진걸 볼수있고
image id가 동일하다는걸 볼수있다.

## docker push hanuijun/mynginx
push to the docker hub!

## docker run -d -p 8080:80 --name webapp -e NAME="MyNginxFromDockerHub" hanuijun/mynginx:1.00
해당 이미지 docker hub에서 가져와서 사용하기
