# Log Converter

## Descrição

Este projeto consiste em um aplicativo de console desenvolvido para converter arquivos de log do formato "MINHA CDN" para o formato "Agora". Este conversor é necessário para gerar relatórios de faturamento compatíveis com  sistema atual de uma determinada empresa.

## Funcionalidades

- **Conversão de Logs**: Converte logs do formato "MINHA CDN" para o formato "Agora".
- **Validação de Entrada**: Verifica se os argumentos fornecidos (URL de origem e caminho de destino) são válidos.
- **Arquitetura Modular**: Segue princípios de POO e SOLID para facilitar a manutenção e a expansão.
- **Testes Unitários**: Inclui testes unitários para garantir a qualidade e o funcionamento correto das funcionalidades.

## Formatos de Log

### Formato "MINHA CDN"
```plaintext
312|200|HIT|"GET /robots.txt HTTP/1.1"|100.2
101|200|MISS|"POST /myImages HTTP/1.1"|319.4
199|404|MISS|"GET /not-found HTTP/1.1"|142.9
312|200|INVALIDATE|"GET /robots.txt HTTP/1.1"|245.1
```


### Formato "Agora"
```plaintext
#Version: 1.0
#Date: 15/12/2017 23:01:06
#Fields: provider http-method status-code uri-path time-taken response-size cache-status
"MINHA CDN" GET 200 /robots.txt 100 312 HIT
"MINHA CDN" POST 200 /myImages 319 101 MISS
"MINHA CDN" GET 404 /not-found 143 199 MISS
"MINHA CDN" GET 200 /robots.txt 245 312 REFRESH_HIT
```


## Como Usar

### Pré-requisitos

- .NET SDK 8.0

### Execução

Para executar o aplicativo de console, use o seguinte comando no terminal:

```sh
dotnet run --project LogConverter.ConsoleApp "sourceUrl" "targetPath"
```
Ou se preferir passar os parâmetros direto no launchsettings.json:

```sh
{
  "profiles": {
    "ConsoleApp1": {
      "commandName": "Project",
      "commandLineArgs": "sourceUrl targetPath"
    }
  }
}

Se tiver utilizando visual studio pode passar clicando com o botao direiro no projeto ConsoleApp
-> Propriedades
-> depurar
-> abrir Depuração
-> incluir argumentos da linha de comando

e passar os parametros no local indicado, que seria o mesmo de passar no json
```
Argumentos
sourceUrl: URL do arquivo de log no formato "MINHA CDN".
targetPath: Caminho onde o arquivo convertido no formato "Agora" será salvo.
