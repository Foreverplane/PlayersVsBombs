# PlayersVsBombs

## Задача:
Сделать сцену - замкнутое пространство, в котором рандомно спавнятся какие-либо персонажи и падают бомбы, которые могут наносить урон. Персонаж может получить определенное кол-во урона, после чего погибает. 
В пространстве рандомно расположены стены.

### Прим.:
Игроки и бомбы спавнятся (см. **CreateFeature**) внутри коллайдера **SpawnAreaView** (дочерний объект префаба **LevelView**) падая из него на поверхность уровня. <br />
Наносимый дамаг зависит от расстояния и объектов между бомбой и игроком. (см. **DamageFeature**) <br />
Стены, имея компонент, **ViewDamageAbsorptionComponent** поглощают дамаг. <br />
(Была идея сделать поглощение анизотропным, но в итоге сделал по-простому)<br /> 
Можно управлять камерой через среднюю и правую кнопку мыши, комбинируя с левыми контролом и альтом получая доп действия. (скрипт камеры — копипаста с юнитевского форума).<br />
Дополнительно можно спавнить игроков кликнув по уровню левой кнопкой мыши.<br />
Разные виды бомб можно спавнить наведя мышку на поверхность уровня и понажимав на 1,2,3 на клавиатуре.<br />
Значения наносимого дамага, кто и кому, значения снижений от дистанции и поглотителей — выведены в дебаг консоль.<br />
Все бомбы наносят дамаг всем сущностям в заданном (в системе создания конкретной бомбы см. **CreateFeature**) радиусе и у которых есть компонент **HealthComponent**.<br />
Бомба 1 (**Spherical** *) – наносит дамаг кому может нанести и уничтожается.<br />
Бомба 2 (**Linear** *) — наносит дамаг, но сама при этом не уничтожается, а получает себе хп, и может быть уничтожена уже другими бомбами.<br />
Бомба 3 (**Fake** *) — дамаг никому не наносит, но уничтожает саму себя. (просто так вот)<br />
*- слова для поиска по солюшену.<br />

## Архитектура проекта:

**GameController** – начинается всё отсюда.  <br />
Загружает провайдер ресурсов и создаёт контекст. <br />

**GameContext : Context** – непосредственно где всё происходит.  <br />
Перекидывает зависимости в системы и создаёт фичи (**Feature**). <br />

**Context** – ядро всей архитектуры. <br />
Через него системы работают с сущностями **IEntity** и вьюшками **View**. <br />
Через него же в системы стреляются ивенты по дженериковому интерфейсу **IEventListenerSystem**. <br />

**Feature** – базовый класс для всех фичей. <br />
Нужен для группового добавления систем (наследников **ContextSystem**) в контекст (просто для удобства). <br />

**ContextSystem** – базовый класс всех систем. <br />
Системы содержат логику работы с вьюшками и **IEntity**. <br />

**Entity : IEntity** – сущность что просто хранит компоненты **IComponent**. <br />

**IComponent** – интерфейс всех компонентов сущности (в том числе и вьюшек). <br />
Компоненты не содержал логики. <br />
(Исключением является **View**, что дёргает назначенный при инстациировании экшн при коллизии (см. **CreateFeature**)) <br />

**IEventListenerSystem<T>** - в результате работы системы стреляют ивентами для исполнения необходимой логики другими системами. <br />

**View : Monobehaviour** – содержит ссылки на компоненты префаба и также является одним из компонентов **IEntity**. <br />

**ViewsLibrary : ScriptableObject** – содержит лист **View** и реализует **IResourceProvider**.   <br />

## Общий принцип работы: <br />

Юнити дёргает **GameController**.<br />
**GameController** создаёт **GameContext** который создаёт системы.<br />
После инициализации **GameContext GameController** стреляет в него ивентом **StartGameEvent**.<br />
**LevelFeature** – загружает уровень.<br />
**SpawnOverTimeFeature** – подбирает точки спавна внутри SpawnAreaView и время от времени стреляет ивентами соответствующими тому что спавнить нужно (наследники **SpawnEvent**).<br />
**SpawnOnClickFeature** – чекает что там пользователь нажал, стреляет райкастом в уровень и потом создаёт конкретные ивенты для спавна.<br />
**CreateFeature** – создаёт сущности игроков и разных бомб в ответ на ивенты спавна.<br />
При загрузке вьюшек задаёт им экшн который они будут дёргать при коллизии (стрельнуть ивентом содержащим данные о коллизии и сущность содержащую саму вьюшку).<br />
**DamageFeature** – ловит ивенты о коллизиях.<br />
При получении ивентов о коллизиях бомб исполняет логику связанную с нанесением дамага.<br />
