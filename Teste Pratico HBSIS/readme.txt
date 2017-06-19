Requisitos para funcionamento da aplicação:
Back:
Visual Studio 2013 ou superior com SQL Server nativo instalado.
Redis Client
RedisDesktopManager

Front:
NPM

Executando a aplicação:
Back:
No Visual Studio, ir na aba "Server Explorer" localizar a conexão CurrentSqlServerConnection(HBSIS.API).
Neste banco, rodar os scripts localizados em - Aba Solution Explorer -> Infrastructure -> HBSIS.SqlServer -> Scripts, na ordem:
1 - DDL_CREATE_TB_USUARIO.sql
2 - DML_INITIAL_TB_USUARIO.sql
3 - USP_TB_USUARIO.sql

Após isso rodar a aplicação (Irá aparecer um erro 404, mas o que importa é estar rodando a API).

Front:
Ir no arquivo HBSIS.WebApp -> app -> constant -> globalSettings.ts e alterar a propriedade API_ADDRESS para o endereço da aplicação da pagina 404.
Na pasta HBSIS.WebApp abrir o prompt de comando como administrador e executar os comandos na sequencia:
1 - npm init -y
2 - npm install
3 - npm start

* Caso de erro na no console do browser, altere o arquivo package.json da pasta HBSIS.WebApp, substituindo todos os modulos com versão 2.0.0-rc.4 para 2.0.0-rc.5. Depois execute os comandos:
1 - npm install
2 - npm start

Após rodar este ultimo comando, deverá abrir o browser com a aplicação já funcionando.



