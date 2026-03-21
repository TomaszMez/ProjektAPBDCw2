Instrukcja uruchomienia:
dotnet run lub przez konsolę w IDE

Decyzje projektowe:

a) kohezja:
Każda klasa *Manager (UserManager, DeviceManager, RentalManager) przechowuje i zarządza obiektami odpowiadających klas modeli oraz decyduje o dostępie do nich z zewnątrz. Walidacja występuje tylko w zakresie niezbędnym do wykonania tych podstawowych zadań.
RentalManager realizuje przy tym część logiki biznesowej konieczną do zapewnienia poprawności procesu wypożyczeń zgodnie z wymaganiami.
Inne klasy serwisowe, takie jak RentalReporter oraz InputParser, realizują wyłącznie zadania wynikające z ich nazw.

b) coupling
Sprzężenia między klasami zostały ograniczone do minimum i występują jedynie w miejscach wynikających bezpośrednio z logiki biznesowej:

- RentalManager przechowuje referencje do obiektów zdolnych zwrócić informacje o użytkowniku i urządzeniu oraz nadpisać dostępność urządzenia (wymuszają to założenia biznesowe). Są to pola o typach będących małymi, wyspecjalizowanymi interfejsami (IUserLookup, IDeviceLookup, IDeviceAvailabilityWriter). Mimo że w scenariuszu pokazowym jako argumenty podawane są obiekty UserManager i DeviceManager, w praktyce RentalManager nie zależy bezpośrednio od tych klas.
- RentalReporter przechowuje referencje do IBulkUserLookup, IBulkDeviceLookup oraz IBulkRentalLookup, przez co jego działanie zależy od wymaganych operacji, a nie od klas UserManager, DeviceManager, czy RentalManager.

c) odpowiedzialność klas
Każda klasa ma jeden cel:

- Klasy *Manager przechowują i zarządzają obiektami odpowiadających klas modeli.
- Klasy: {Device, Laptop, Camera, Projector, User, Rental} reprezentują elementy modelu domenowego. Ich odpowiedzialność ogranicza się do przechowywania stanu, kopiowania swoich obiektów oraz prezentacji tekstowej (ToString()).
- RentalReporter zwraca raport o stanie systemu.
- InputParser zamienia tekst w obiekt modelu.

Zdecydowałem się na taki podział klas, aby oddzielić obiekty domenowe od logiki aplikacji.
Logika ta została rozdzielona między klasy UserManager, DeviceManager i RentalManager, aby uniknąć jednej rozbudowanej klasy „od wszystkiego”.
Ponadto wydzieliłem klasy pomocnicze InputParser oraz RentalReporter, dzięki czemu ich funkcjonalność nie miesza się z logiką aplikacji.
Chcąc zminimalizować sprzężenie klas, podzieliłem funkcjonalności klas *Manager na kilka mniejszych kontraktów.

Uznałem ten podział za sensowny, ponieważ poprawia czytelność kodu oraz ułatwia jego modyfikację w przyszłości.