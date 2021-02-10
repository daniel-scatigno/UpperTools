# UpperTools

## Sobre o projeto
### Feito por Daniel Guimarães Scatigno
### Teste para Processo Seletivo, Uppertools descreve o seguinte Problema:
Um cliente possui diversos tipos de contas que não são gerenciadas: água, energia, taxi, locação de veículos e hospedagem de funcionários. E comumente acarreta problemas como falta de visibilidade dos custos, uso irresponsável dos recursos, multas por atraso no pagamento e muito trabalho para gerar relatórios de rateio dos custos.

Uma dificuldade é que cada fornecedor envia suas faturas em um formato: XLS, CSV, XML, PDF e JSON. Os layouts dos arquivos também variam de fornecedor para fornecedor.

Seu trabalho é projetar uma solução para importar os dados de faturamento de cada fornecedor para um software que irá gerar gráficos, relatórios e análises para os usuários.

É importante que sua solução seja flexível para que seja simples adicionar novos arquivos de novos fornecedores.

É importante você explicar como sua solução poderá escalar para ao mesmo tempo processar diversos arquivos e performar o suficiente para processar arquivos de até 10GB.


## Diagramas
Para descrever o uso do sistema foram criados Diagramas UML
###  Casos de Usos [Gerenciar Fatura](GerenciarFaturas.ucase.violet.html) 
- Instalar o PostgreSQL server
- Adicionar um usuário (trduser) com super privilégios
- Crie um banco de dados com estes parametros: 
  - Database Name = "TRADE"
  - Address = "localhost"
  - Port = 5432
  - User = "trduser"
  - Password="testeeduzz"

PS: É possivel configurar estes parametros na aplicação.
- Você encontra o arquivo de configuração dentro da pasta bin/Config

### Rodando no Linux
- Instalar o .net SDK 3.1 para Linux https://dotnet.microsoft.com/download/dotnet-core/3.1
- Instalar  o Visual Studio Code para Linux https://code.visualstudio.com/download
- Instalar a extensão C# Extension para Visual Studio Code
- Você pode rodar esta aplicação abrindo o projeto (Pasta) no Visual Studio Code
e apertando F5(Run)

## Frameworks e informação sobre o projeto
### Sobre
- Este projeto esta dividido em 3 modulos seguindo a arquitetura Domain Driven Desgin
  - TesteBackendEduzz.Api contento os Endpoints e Controllers (camada exposta ao usuário)
  - TesteBackendEduzz.Domain contento Modelos e regras para armazenar os Dados
  - Eduzz.Infrastructure contento classes de ajuda no desenvolvimento e podem ser expostas a outros projetos

- Operações de banco de dados são feitas por um Repositório (Repository Pattern)
  - Não é necessário (mas é possivel) criar operações (CRUD operations) para cada entitade, essa funcionalidade é entregue através da herança de classes

- Ações (interações do usuário), são validadas para cada Modelo usando Atributos de Validação (Diminui a quantidade de código necessária)
  - Se um post for bem sucedido ele retorna o código 200 com informações do objeto
  - Se um post é invalido por causa das informações ele retorn 422(Entidade não validada) com detalhes dos erros para cada propriedade
  - Modelos são validados automaticamente para cada método decorado com o atributo [ValidateModel] e as mensagens de erro
são especificadas para cada propriedade do modelo
  - Cada resultado Json tem uma propriedade statusCode e uma propriedade result ou errors mostrando cada erro detalhadamente
e uma propriedade message mostrando o erro de modo geral

- Moeda Virtual
  - Este projeto é sobre Moedas Virtuais, com a possibilidade de comprar e vender
  - Eu tentei tratar o mais proximo possivel deste projeto como um Software de TRADE
  - Eu criei uma Classe de Carteira que contém informação sobre o dinheiro do usuário
    - O dinheiro pode ser Real(BR), Bitcoin ou até mesmo Dolar(Not used)
  - Cada vez que um usuário compra ou vende uma Transação de Dinheiro é criada
   contendo a informação sobre a carteira de destino (ou fonte) e a quantidade transferida


### Frameworks
- Este projeto usa o NHibernate como ORM e Mapping by Code para mapear as Entidades
- Este projeto usa Sendgrid para envio de e-mails
 
### Postman teste
Eu exportei os arquivos [collection](postman_collection.json) e [Environment](postman_environment.json)

