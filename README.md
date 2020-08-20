# О проекте
Для графической части использовались векторные изображения. Игра выполнена в жанре Tamagochi-like game, т.к. данный жанр хорошо поможет понять основы ООП и работу с UI.
# Блок-схема
![diagram](https://sun9-14.userapi.com/0pFuDu1FtqGWuv2G2Uz0gSdQBuMTe6t56MIbLw/BAr5MleKeuc.jpg)
![diagram](https://sun9-45.userapi.com/8DTBpiajKP09Dwb3MivyXpRrDKYA4YmKioZbLA/VYiuLODGk6o.jpg)
# Процесс игры
Главная задача,поддерживать основные потребности питомца. В игре 5 локаций, каждая из локаций отвечает за свою потребность.
## Диаграмма предметной области
![diagram](https://sun9-16.userapi.com/t23h4Vc012vXI6xLIPr4LOHkddYtQwNgDgDTdw/BK_Q3INksvg.jpg)
## Игровая комната
В игровой комнате, необходимо ловить различные продукты в корзину за определенное время, по окончанию времени выдается опыт и валюта, а так же шкала потребности заполняется.

![screen](https://sun9-58.userapi.com/Ecjzq4pE72u-Iw92rNL6B8RnOWNRLmPyRD_ueg/E4Z5ws1dMbs.jpg)

Объекты(продукты) создаются из префаба, текстура объекта выбирается случайно из общего списка текстур
```csharp
public void InitializedTexture()
    {
        triggerTexture[1] = "Apple";
        triggerTexture[2] = "Bannana";
        triggerTexture[3] = "Cabbage";
        triggerTexture[4] = "Carrot";
        triggerTexture[5] = "Eggplant";
        triggerTexture[6] = "Orange";
        triggerTexture[7] = "Radish";
        triggerTexture[8] = "Strawberry";
    }
```
Через n количество времени появляются новые объекты
```csharp
private void Update()
    {
        timer -= Time.deltaTime;
        if (timer<=0)
        {
            SpawnObject();
            timer = 2;
        }
    }
```
Непосредственно алгоритм создания объекта
```csharp
public void SpawnObject()
    {
      //Задаются координаты создания объекта
        CoordinatesSpawn();
      //Создание объекта
        deleteObj = Instantiate(fallingObject, new Vector3(xSpawn, ySpawn, zSpawn), Quaternion.identity);
      //Внесение в иерархию Canvas  
        deleteObj.transform.SetParent(canvas.transform);
        deleteObj.SetActive(true);
    }
```
## Кухня
В локации Кухня, чтобы пополнить индикатор потребности, необходимо нажать на кнопку "Food"

![screen](https://sun9-47.userapi.com/ncPMomGdLG0qIZB-szR0KIfpQtyRr5_Y4vRolg/PLBX-yr0hIA.jpg)

Алгоритм пополнения индикатора потребности
```csharp
private void Update()
    {
    //Если срабатывает триггер
        if (StartGame.changeFood)
        {
        //Заполняется индикатор
          iconfood.fillAmount += 0.25f;
        //Выключается триггер
          StartGame.changeFood = false;
        //Изменяется вид еды
          ChangeFoodTexture();
        //Выдача опыта
          if (iconfood.fillAmount <= 0.75f)
          {
                XPProcess.giveexpforgame = true;
          }
        }
    }
```
