Simple Tasks

stage 1
- [x] интеграция с GitHub ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
- [x] танк - один типовой, заранее настроенный ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
- [x] возможность стрелять одним одним типом снарядов ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
- [x] фича - хп у игрока и противников(не отображается) + IDamageable у снарядов/танков ^^^^^^^^^^^^^^
- [x] (GameManager) - следит за игроком, и если ему звезда - завершает игру ^^^^^^^^^^^^^^^^^^^^^^^^^^
- [x] бэкграунд - ровно одна типовая местность для игры ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
- [x] фича - gun - fireRate - стрельба по cooldown ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
- [x] фича - camera zoom ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
- [x] Фича - объекты на карте ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
  - [x] укрытия - проехать и стрелять нельзя ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
- [х] ИИ Противника - радиус обзора(задаётся в Inspector) ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
      1 - если видит Игрока, стреляет в его сторону. ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
      2 - N(рандомно 1-10) сек едет в одну сторону, потом рандомно меняется сторону(сторона света)^^^^
- [x] исправить не корректное поведение при движении назад ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
- [x] аудио библиотека  - enum аудио-файлов 
- [ ] аудио WorldAudioPlayer(scene singleton) - слушает ивенты WorldAudio*** и управляет 
        коллекцией звуковых компонентов внутри.
- [x] звук при:^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
  - [x] выстрел танка ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
  - [x] уничтожение танка ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
- [ ] AfterDeadPrefab - Префаб объекта с настройками и компонентами, что создаётся после смерти 
        Другого объекта, например Взрыв(анимация и звук) после уничтожения снаряда или танка.

stage 2
- [ ] Spawn Zone танков - создаёт танки внутри себя(Collider2D), точно место выбирается случайно. 
- [ ] модель уничтожения танка - взрывы и т.п.
- [ ] 2 Типовый Танка(тяжолый и лёгкий) 
  - [ ] Типовой танк, это когда мы можем Перенести PlayerController ИЛИ AIController в Другой танк и оно будет Хорошо работать.
- [ ] UI
  - [ ] HP игрока
  - [ ] меню начала игры
- [ ] Фича - объекты на карте
  - [ ] препятствие - проехатьнельзя, а стрелять можно
   - [ ] бонусы :
    - [ ] ремонт
    - [ ] ускорение
    - [ ] Усиление урона
- [ ] анимация траков работает только если танк едет, если поварачивает - работает только один, но только если на месте
- [ ] звуки - AudioManager
  - [ ] передвижение танка
  - [ ] взрыв снаряда (не важно обо что)
- [ ] бэкграунд - несколько карт на выбор
- [ ] ИИ - хаотично катаются и стреляют, возможно даже в игрока.(хз на сколько там всё будет заморочно сделать Хорошо, для начала просто Присутствие ИИ как Двигателя левых танков)

stage 3
- бэкграунд - примитивно-тупая генерация карты бэкграунда
- уровни сложностей - какая реализация????
- Физики повреждений
  - Корпус - сопротивление урону в зависимости от стороны попадания
  - Башня - от башни зависит скорость вращения
  - Ствол - скорость перезарядки, с двумя стволами - отдельная перезарядка для каждого и возможность шмальуть два раза подряд
  - Гусеницы - скорость танка (с учётом того что башня и корпус дают разную массу)
  - фабрика по сбору танков из Деталей.
- UI - создание танка игрока в UI перед началом игры

stage 4
- урон от тарана (учитывает массу танка и сторону удара)
- Фича - объекты на карте 
  - вызвышенность - поехать нельзя - стрельба в одну сторону - С Возвышенности
  - бонус - защитное поле :)
  - туман войны? :)
  - secondary wepon? - курсовые ракеты или круговой электро-шок
  - Команды? - 5 vs 5 ? перенос Игрока в другой танк команды в случаи смерти?
