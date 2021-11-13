# JogosEmPromocoesApi

Esse projeto tem como objetivo listar os jogos que estão em promoção nas lojas de jogos digitais mais populares.

Este projeto é apenas o back-end no qual faz a extração dos dados dos sites da EPIC, STEAM e GOG.

para acessar o site front-end, acesse - https://saraiva1989.github.io/JogosEmPromocoes/

![image](https://user-images.githubusercontent.com/40599423/141598821-46bd35a9-cc4a-4162-942a-6bada88d4ad4.png)

![image](https://user-images.githubusercontent.com/40599423/141598888-6e4aaa5f-5adb-4a0e-b0bf-1d2a9d1dd0fc.png)


# Tecnologia usada

Foi usado .net 5 para desenvolver a API, e utilizado a biblioteca HtmlAgilityPack para extrair os dados do STEAM, pois o site do steam não utiliza endpoint em JSON, e sim uma API que retorna HTML. Sendo assim foi necessário fazer a leitura do HTML para montar o retorno da API.

Já as lojas EPIC GAME e GOG possuem API com retorno JSON, sendo assim foi apenas tratada para trazer o objeto de acordo com a necessidade do projeto.

# Contribuir com projeto

## Programador
Se você é um programador e deseja contribuir no projeto, pegue uma ISSUE (caso exista) e faça um fork do projeto. Faça a correção no branch de DEV e envie o PULL REQUEST. Prontinho ajudou no projeto 🦖

Caso não tenha a ISSUE e queira implementar algo, crie a ISSUE com o problema/implementação e comece a trabalhar nela



## Não Sabe Programar
Se você não é programador e quer contribuir, pode criar uma ISSUE com sua ideia de melhoria ou notificando um problema.

