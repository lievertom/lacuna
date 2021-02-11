# lacuna

Esse repositório tem como objetivo guardar a solução para participação do processo seletivo de estágio na [Lacuna Software](https://www.lacunasoftware.com/en/).

## Processo Seletivo

A primeira etapa da seleção é um teste prático. A tarefa é simples: forjar o login de um usuário privilegiado em um sistema com falhas de segurança. 

- [instruções](https://lacun.as/desafio)

## Solução Proposta

O código foi desenvolvido na linguagem **C#** com o auxílio do *framework* [.NET 5.0](https://dotnet.microsoft.com/download) em ambiente linux, [Ubuntu 20.04 LTS](https://releases.ubuntu.com/20.04/).

O programa basicamente cria dois usuários e a partir dos tokens recebidos é possível extrair algumas informações necessárias para forjar o token de usuário master, são elas: a posição do  nome de usuário cifrado no token e o caracter para completar os espaços em branco. Após gerar o token de usuário master é feita uma requisição adicionando o token ao cabeçalho. Se o processo ocorrer sem falhas temos como resposta uma mensagem secreta. 

## Execução

Clone ou baixe o projeto e dentro do diretório do projeto execute:

```bash
dotnet run 
```

## Referências

- [Documentação C#](https://docs.microsoft.com/pt-br/dotnet/csharp/);

- [Steve Gordon ( MVP Microsoft)](https://www.stevejgordon.co.uk/).

## Autor

[Lieverton Santos](https://lievertom.github.io/)
