build:
	docker-compose build

up:
	docker-compose up -d

down:
	docker-compose down --remove-orphans

logs:
	docker-compose logs -f