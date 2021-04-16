build:
	docker-compose build

up:
	docker-compose up -d

down:
	docker-compose down --remove-orphans

logs:
	docker-compose logs -f

db-up:
	docker-compose up -d mysql

db-down:
	docker-compose stop mysql

mongo-up:
	docker-compose up -d mongo

mongo-down:
	docker-compose stop mongo

me-up:
	docker-compose up -d mongo-express

me-down:
	docker-compose stop mongo-express
