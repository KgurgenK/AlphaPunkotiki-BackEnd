# AlphaPunkotiki-BackEnd

Цель проекта:
Разработать пространство, где предприятия, которым необходимо узнать мнение определенной целевой аудитории на интересующую тему, создают и проводят опросы и интервью. Респонденты - также пользователи данной площадки, желающие проходить опросы на возмездной основе.

Проект разбит на 3 слоя:
AlphaPunkotiki.Domain - Сущности 
AlphaPunkotiki.Infrastructure - Инфраструктура
AlphaPunkotiki - Основная логика


Базовые классы: Entity и Offer в AlphaPunkotiki.Domain/Entities/Base/
Базовые интерфейсы: IAggregationRoot     AlphaPunkotiki-BackEnd/AlphaPunkotiki.Domain/Entities/Interfaces

Точки расширения:
[  ] Авторизация
[  ] Монетизация
[  ] Добавление новых видов вопросов
[  ] Добавление новых видов предложений

Для расширения функционала опросов и интервью:
IInterviewsService 
ISurveysService