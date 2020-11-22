# SwidnikHackaton API
API pozwala na pobranie danych z bazy danych postawionej w Azure. Baza wypełniana jest na bieżąco na podstawie danych z naszej własnej aplikacji mobilnej. 
API zwraca dane w postaci JSON.

# Dane 
Dane przechowane są w postaci - id sesji, długość i szerokość geograficzna oraz timestamp. Hasz sesji pozwala na połączenie punktów wyrażonych za pomocą długości i szerokości geograficznej i uporządkowanie ich w trasę jaką przebył użytkownik aplikacji na podstawie znacznika czasu. 
Dane zapewniają pełną anonimowość użytkownika - aplikacja pobiera dane w momencie gdy użytkownik zacznie zmieniać swoje położenie - dłuższy postój oznacza koniec sesji, ponowne rozpoczęcie ruchu oznacza nową sesje. 

# Endpoint
GET /PedestriansTraffic - zwraca wszystkie zapisane punkty, sesje i czasy.  
GET /PedestriansTraffic/GetProcessedData - zwraca wszystkie zapisane punkty, pogrupowane dla id sesji.  
POST /Insert?guid=<guid>&latitude=<latitude>&longitude=<longitude> - guid to id sesji, latitude to szerokość geograficzna, longitude to długość geograficzna.  
