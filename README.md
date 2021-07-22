# Escape Room
 Um jogo de Escape Room 3D com câmera em primeira pessoa desenvolvido em Unity. 
 Todas as artes e sons são de Assets gratuitos. 
 As artes dos puzzles são placeholders. 
 Toda a programação e parte das animações foi desenvolvida por mim, Bruno Gattai.

Como jogar:
- Execute o arquivo "Escape Room.exe" que se encontra na pasta "Build" em um computador Windows.

Como abrir o código fonte:
- Utilizar a versão da Unity 2020.3.14 (LTS)

Comandos:
- Andar: WASD
- Virar a câmera: Movimento do Mouse
- Interagir: E
- Voltar: Q ou ESC

Features:
- 4 puzzles com mecânicas diferentes.
- 2 Cutscenes com o sistema de Timeline da Unity.
- Sistema de cartas que revelam informações da história.
- Sistema de interações com os objetos do cenário.
- Sistema de objetos físicos que podem ser segurados e combinados com outros objetos interagíveis, por exemplo: chaves que abrem trancas.
- Sistema vitória e game over, integrados a um sistema de trancas na porta de saída e um sistema de timer, respectivamente.

Resolução dos puzzles:
- Puzzle 1 (Geometric Forms Puzzle, encontra-se em uma das paredes) - Esse é o único puzzle opcional do jogo e só revela uma parte da história quando é completado. Para completar o puzzle, clique nas imagens para alterá-las, de modo que formem as formas geométricas nessa ordem: Quadrado, Losango, Triângulo e Círculo.
- Puzzle 2 (Sequence Puzzle, encontra-se em cima do tambor ao lado da porta de saída) - Para completar o puzzle, clique nos botões nessa ordem: 4, 7, 6, 8, 3, 10, 2, 5, 9 e 1.
- Puzzle 3 (Password Puzzle, encontra-se em um dos cadeados da porta de saída) - Para completar o puzzle, clique nos botões para inserir a senha que é encontrada em uma das cartas de Alice (personagem do jogo), de modo que os númros fiquem na seguinte ordem: 963.
- Puzzle 4 (Slide Puzzle, encontrado em uma das paredes) - Alinhe as peças em ordem numérica para completar o puzzle, para completar facilmente, clique nas peças nessa ordem: 8, 7, 4, 5, 1, 2, 3, 6, 5, 4, 7 e 8.

Condição de vitória:
- Abrir a porta de saída. A porta possui 3 trancas. 
- Para abrir a tranca "Old Padlock", use a chave "Old Key" que pode ser encontrada na gaveta esquerda do armário.
- Complete o puzzle "Password Puzzle" e abra uma das trancas inserindo a senha 963. Essa senha pode ser econtrada na carta "Alice's Letter 3", que por sua vez é liberada ao completar o puzzle "Slide Puzzle".
- Complete o puzzle "Sequence Puzzle" para desbloquear a chave "Small Key" que abre a última tranca da porta chamada "Door Lock".

Condição de derrota:
- É ativada se o tempo do Timer chegar a zero.
