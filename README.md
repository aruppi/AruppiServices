# AruppiServices

#### URL
- https://aruppi.herokuapp.com/

## Services

### Schedule
### Api/Aruppi/Schedule
#### Params
	Day

El servicio devuelve la programación del día que le pidas, el día tiene que enviarse en ingles

### MoreInfo
### Api/Aruppi/MoreInfo
#### Params
	id
	
El servicio devuelve la información del id correspondiente de la api de jinkan

### News
### Api/Aruppi/News

Devuelve las noticias de somoskudasai

### Season
### Api/Aruppi/Season
#### Params
	year
	seasons
	
Devuelve los animes de un año y una temporada, ejemplo:
- https://aruppi.herokuapp.com/Api/Aruppi/Season?year=2019&seasons=winter
### Ivoox
### Api/Aruppi/Ivoox


### GetAnime
### Api/Aruppi/GetAnime
#### Params
	name
	numPag
Devuelve los capítulos de un anime, el numpag no es obligatorio en caso de que el anime tenga pocos capítulos
El json devuelto tiene la propiedad episodes_last_page que te dira cuantas páginas tiene de episodios

### GetEpisode
### Api/Aruppi/GetEpisode
#### Params
	name
	numCap

Devuelve la URL del capítulo del anime que le pidas, ejemplo:
- https://aruppi.herokuapp.com/Api/Aruppi/GetEpisode?name=one%20piece&numcap=1

### GetLastEpisodes
### Api/Aruppi/GetLastEpisodes

Devuelve los últimos episodios añadidos

### SearchAnimeFlv
### Api/Aruppi/SearchAnimeFlv
#### Params
	name

Devuelve anime, pelicula, etc de la serie que le pidas, ejemplo:
- https://aruppi.herokuapp.com/Api/Aruppi/SearchAnimeFlv?anime=one-piece

### SearchServersFlv
### Api/Aruppi/SearchServersFlv
#### Params
	id

Devuelve todos las urls de los capítulos de cada server

### SearchMoviesFlv
### Api/Aruppi/SearchMoviesFlv
#### Params
	pag

Devuelve las películas por páginas.

### SearchOvasFlv
### Api/Aruppi/SearchOvasFlv
#### Params
	pag

Devuelve las OVAS por páginas.


### SearchSpecialsFlv
### Api/Aruppi/SearchSpecialsFlv

Devuelve los especiales por páginas.


# Apis de las que se extrae la información

# Https://api.jikan.moe/v3/
# https://anime-pictures.net/pictures/view_posts/
# https://ryuanime-api.chrismichael.now.sh/api/v1/
# https://animeflv.chrismichael.now.sh/api/v1/
# https://somoskudasai.com/feed/
# https://www.ivoox.com/podcast-anitakume_fg_f1660716_filtro_1.xml