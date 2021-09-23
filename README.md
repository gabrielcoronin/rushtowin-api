# RushToWin API
#
#### Web API desenvolvida em .NET para consumo do App desenvolvido em Flutter

* [RushToWin - Flutter](https://github.com/gabrielcoronin/rushtowin)

#
#
# 

## Instruções

1. Criar um diretorio para instalar o projeto
 
3. ``` git clone  https://github.com/gabrielcoronin/rushtowin-api.git``` 

3. ``` docker-compose up ```

   
#
#
#

## Mapeamento de End-points

A aplicação possui os seguintes end-points:

#

###  Usuários



- `/api/Users/{id}`:
    - **GET**

    - Recebe o Id do usuário. Retorna o usuário e a carteira correspondente.
  
        ```csharp
        {
            "id": "f7edea49-701c-4941-87d0-6a72b7128344",
            "fullName": "Gabriel Coronin",
            "cpf": "123123123123",
            "email": "gabrielcoronin@gmail.com",
            "password": "qa",
            "createdAt": "2021-09-20T14:29:52.430343",
            "updatedAt": "2021-09-20T14:29:52.430434",
            "walletId": "1feb4050-53eb-4cab-847b-e4460638aa31",
            "wallet": {
                "id": "1feb4050-53eb-4cab-847b-e4460638aa31",
                "balance": 0
            }
        }
        ```

   #
   #



- `/api/Users`:
    - **POST**
      - 
      ```csharp
        {
            "fullName": "gabriel coronin",
            "cpf": "12312312312",
            "email": "aa@gmail.com.br",
            "password": "123"
        }
      ```


    - Recebe nome completo, cpf, email e senha. Retorna o usuário e a carteira.
  
        ```csharp
        {
            "id": "6c9d353f-f45d-4b78-928d-53e7b71c1a6d",
            "fullName": "gabriel coronin",
            "cpf": "12312312312",
            "email": "aa@gmail.com.br",
            "password": "123",
            "createdAt": "2021-09-21T01:43:26.9196927Z",
            "updatedAt": "2021-09-21T01:43:26.9197448Z",
            "walletId": "c0093805-acaf-4d16-96a9-c72b27a09903",
            "wallet": {
            "id": "c0093805-acaf-4d16-96a9-c72b27a09903",
            "balance": 0
            }
        },
        ```

        
#
#


- `/api/Users/`:
    - **PUT**
      - 
      ```csharp
      {
        "id": "758ac903-c0c5-4129-a01f-684d984b8c60",
        "fullName": "Gabriel Coronin",
        "cpf": "123123123123",
        "email": "gabrielcoronin@gmail.com",
        "password": "qaa"
      }
      ```


    - Recebe id, nome completo, cpf, email e senha. Retorna o usuário atualizado e sua carteira correspondente.
  
        ```csharp
        {
        "id": "f7edea49-701c-4941-87d0-6a72b7128344",
        "fullName": "Gabriel Coronin",
        "cpf": "123123123123",
        "email": "gabrielcoronin@gmail.com",
        "password": "qa",
        "createdAt": "2021-09-20T14:29:52.430343",
        "updatedAt": "2021-09-20T14:29:52.430434",
        "walletId": "1feb4050-53eb-4cab-847b-e4460638aa31",
        "wallet": {
            "id": "1feb4050-53eb-4cab-847b-e4460638aa31",
            "balance": 0
            }
        }
        ```

        
#
#


- `/api/Users/updatePassword`:
    - **PUT**
      - 
      ```csharp
      {
          "id": "758ac903-c0c5-4129-a01f-684d984b8c60",
          "password": "qaa"
      }
      ```


    - Recebe id e senha. Retorna o usuário com a senha atualizada e a carteira correspondente.
  
        ```csharp
        {
        "id": "f7edea49-701c-4941-87d0-6a72b7128344",
        "fullName": "Gabriel Coronin",
        "cpf": "123123123123",
        "email": "gabrielcoronin@gmail.com",
        "password": "qa",
        "createdAt": "2021-09-20T14:29:52.430343",
        "updatedAt": "2021-09-20T14:29:52.430434",
        "walletId": "1feb4050-53eb-4cab-847b-e4460638aa31",
        "wallet": {
            "id": "1feb4050-53eb-4cab-847b-e4460638aa31",
            "balance": 0
            }
        }
        ```

    

#
#
#

### Transações




- `/api/Transactions/recharge`:
    - **GET**
      - 
      ```csharp
      {
          "walletId": "f8a9719b-e846-42cd-827b-b0e8bf4f86cc",
          "value": 5
      }
      ```


    - Recebe o id da carteira e o valor a ser adicionado. Não retorna nada.  
     

        
#
#



- `/api/Transactions/bus/{walletId}`:
- `/api/Transactions/subway/{walletId}`:
- `/api/Transactions/train/{walletId}`:

    - **POST**
      -     

    - Recebe id da carteira. Retorna uma nova transação e a carteira com o saldo atualizado.
  
        ```csharp
        {
            "id": "894c7735-000d-4ece-a1ef-3c357c1d4628",
            "value": 7,
            "createdAt": "2021-09-21T17:22:51.4253618+00:00",
            "wallet": {
                "id": "c94df927-4838-48c8-922f-fb140af05bac",
                "balance": 125
            }
        }
        ```

#
#


- `/api/Transactions/{walletId}`:
    - **GET**

    - Recebe id da carteira. Retorna todas as transações feitas pelo usuário ordenadas pela data em ordem decrescente e o saldo atualizado.
  
        ```csharp
        [
            {
                "id": "0bfd3232-f745-4c51-8b2d-8bc699aa3c1d",
                "value": 5,
                "createdAt": "2021-09-20T15:28:53.868209",
                "wallet": {
                "id": "f8a9719b-e846-42cd-827b-b0e8bf4f86cc",
                "balance": 3
                }
            },
            {
                "id": "5e318434-7a56-439a-bf04-6d8c86317164",
                "value": 5,
                "createdAt": "2021-09-20T15:29:00.616607",
                "wallet": {
                "id": "f8a9719b-e846-42cd-827b-b0e8bf4f86cc",
                "balance": 3
                }
            },
            {
                "id": "9dbb6688-5636-4cb5-a54e-43b1779f1fb5",
                "value": 7,
                "createdAt": "2021-09-20T15:29:32.628559",
                "wallet": {
                "id": "f8a9719b-e846-42cd-827b-b0e8bf4f86cc",
                "balance": 3
                }
            },   
 
        ]
        ```


#
#

- `/api/Transactions/getWallet/{walletId}`:
    - **GET**

    - Recebe id da carteira. Retorna o saldo atualizado.
  
        ```csharp
        {
            "id": "c94df927-4838-48c8-922f-fb140af05bac",
            "balance": 147
        }
        ```


#
#

- `/api/Transactions/lastTransaction/{walletId}`:
    - **GET**

    - Recebe id da carteira. Retorna a ultima transação feita pelo usuário e o saldo atualizado.
  
        ```csharp
        {
            "id": "38641440-2aec-4340-96ee-954fe5a4a4a2",
            "value": 3,
            "createdAt": "2021-09-21T15:19:29.505764",
            "wallet": {
                "id": "c94df927-4838-48c8-922f-fb140af05bac",
                "balance": 150
            }
        }
        ```
