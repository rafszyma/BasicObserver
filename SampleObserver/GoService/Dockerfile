FROM golang:latest

WORKDIR /app

COPY GoService/go.mod .

COPY GoService/go.sum .

RUN go mod download

COPY . .

ENV PORT 8000

RUN go build

CMD ["*/main"]