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
## Спальня
Чтобы восполнить индикатор сна, необходимо по нажатию кнопки дать питомцу отдохнуть n количество времени
```csharp
private void Update()
    {
    //Проверяем спит ли наш питомец
        if (ChangeSceneOnLightning.onLightning && isDream)
        {
        //Затемняем экран
            dreamback.SetActive(true);
        //Пополняем индикатор
            lightningBar.fillAmount += 0.001f;
        }
    }
```
## Кабинет
В кабинете, чтобы повысить индикатор знаний, необходимо пройти мини-игру, где нужно решать примеры



Чтобы решить пример, нужно вычислять заданные примеры, перетаскивая квадраты в соответствующие ячейки
Для реализации данной мини игры были подключены 3 интерфейса
```csharp
public class Drag_Hand : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
```
Интерфейс OnBeginDrag необходим для запоминания начальных позиций, в случае неудачи, можно вернуть квадрат на начальное положение
```csharp
public void OnBeginDrag(PointerEventData eventData)
    {
    //Запоминаем объект
        itemBeingDragged = gameObject;
    //Запоминаем позицию объекта
        startPosition = transform.position;
    //Запоминаем объект в иерархии
        startParent = transform.parent;
    //Выносим объект из CanvasGroup
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
```
Интерфейс OnDrag переносит объект за курсором
```csharp
public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
```
OnEndDrag соответственно необходим для завершения переноса квадрата с ответом, в соответствующую ячейку
```csharp
public void OnEndDrag(PointerEventData eventData)
    {
    // Обнуляем переменную, где хранился объект
        itemBeingDragged = null;
    // Вносим объект в CanvasGroup
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    // Вносим объект в иерархию 
        if (transform.parent != startParent)
        {
            transform.position = startPosition;
        }
        transform.position = startPosition;
    }
```
При запуске сцены, вычисляется следующее
```csharp
private void StartGame()
    {
    // Обнуляются результаты
        Reset();
    // Выбирается метод(+,-,*,/)
        ChoiseMethod();
    // Запоминаем ответ
        comparisonResultExample1 = resultExample;
    // Выводим пример
        exampleText1.text = writeText;
    // Запоминаем ответ для комбинации*
        coderesult1 = resultExample;
    }
```
> **Примечание** * - Алгоритм такой, чтобы победить необходимо собрать комбинацию правильного ответа. 

![screen](https://sun9-51.userapi.com/72pdRXrmsERwIjdEi4RvVR6flFqHmUHS6ZEM6g/6mfyWvSudQ0.jpg)
На изображении три примера, при создании каждого из них в отдельную переменную записывались их ответы, это и есть комбинация для победы. Для данного рисунка комбинация для победы будет 0-5-8, как только пользователь наберет такую же комбинацию, игра посчитает что все примеры решены верно и создаст новые, перезаписав комбинацию на новую соответственно.

```csharp
// Запись комбинации
trueresult.text = string.Format("{0}-{1}-{2}-", coderesult1, coderesult2, coderesult3);
```

Генерация прмеров происходит через оператор Case
```csharp
//Переменная method имеет случайное число от 1 до 4
switch (method)
        {
        //  Сложение
            case 1:
                  
              // Вычисление результата
                resultExample = term1 + term2;
              // Вывод примера
                writeText = string.Format("{0} + {1} =",term1,term2);
                break;
        //  Вычетание
            case 2:
                resultExample = term1 - term2;
                writeText = string.Format("{0} - {1} =", term1, term2);
                break;
        // Умножение
            case 3:
                resultExample = term1 * term2;
                writeText = string.Format("{0} * {1} =", term1, term2);
                break;
        //  Деление
            case 4:
              // Если делитель равен нулю, генерируем новые числа
                while (term1 % term2 != 0)
                {
                    term1 = Random.Range(0, 10);
                    term2 = Random.Range(0, 10);
                }
                resultExample = term1 / term2;
                writeText = string.Format("{0} / {1} =", term1, term2);
                break;
        }
```
