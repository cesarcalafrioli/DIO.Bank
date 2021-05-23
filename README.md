# DIO Bank #



Atividade do laboratório em c# oferecido pela Digital Innovation One. Trata-se um sistema bancário em que o usuário pode criar e listar contas, bem como transferir, sacar e depositar.



### Atualizações ###

##### 23/05/2021 #####

- Melhoria na interface console do usuário.
- Melhoria no menu.
- A função de limpar a tela no menu foi removida.
- As funções de transferir, sacar, depositar e consultar saldo agora verificam se a lista está vazia. Caso esteja, a operação é interrompida.
- Melhoria na função de criar conta. Agora o sistema consulta primeiro se já existe alguma conta com o nome informado pelo usuário.
- Melhoria na função de transferir. Agora o sistema consulta primeiro se a conta de origem e de destino existem logo após ser informado seus respectivos números antes de realizar a transferência. O sistema também não permite mais que a conta de destino seja a mesma da de origem.
- Melhoria na função de sacar. Agora o sistema consulta primeiro se determinada conta existe antes de solicitar o valor a ser sacado e também informa o nome do usuário após este informar o número da conta.
- Melhoria na função de depositar. Agora o sistema consulta primeiro se determinada conta existe antes de solicitar o valor a ser depositado.
- Adicionada a funcionalidade de consultar o saldo.

##### 22/05/2021 #####

- Melhoria na função de depositar. Agora o sistema informa se o saldo foi realizado ou não com sucesso.

- Melhoria na interface console do usuário.

##### 20/05/2021 #####

- Início do projeto