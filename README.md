# Trading strategies tester
# 1. Название проекта:

Trading strategy tester

# 2. Список студентов:

- Плотников Никита, 19137
- Фокин Иван, 19137
- Чистяков Даниил, 19144

# 3. Проблема, которую решает проект:

  На сегодняшний день создано множество различных стратегий для трейдинга. Но на данный момент не существует удобного приложения, которое будет
проверять их эффективность. Наша цель - облегчение тестирования стратегии, а именно создание приложения, которое:

- Поддерживает несколько языков программирования для написания стратегии (для прототипа будет доступен python),
- Имеет уже настроенную работу (через доступные API) с некоторым списком бирж (для прототипа будет доступна работа с binance),
- Выдает подробную статистику о тестируемой стратегии.
- Если человеку понравилась написанная стратегия, то он может собрать бота для торговли на реальном счету.

# 4. Основные компоненты системы: 


# 5. Описание точек расширения:
- Добавление поддержки API других бирж
- Добавление поддержки новых языков программирования
- Добавление ml для улучшения написанной стратегии

# Доступные API запросы:
/candlestick/ticker - get запрос, получение всех возможных торговых пар на данной биржи.

/candlestick/klines - get запрос, получение информации о японских свечек за определенный промежуток.

/strategy - get запрос, запуск проверки стратегии.

/file - post запрос, загрузка файл расширения .py (или любого другого доступного формата) со стратегией.
