chessBoardSide = 8

chessBoard = []
rowStart = 0
for rowIndex in range(0, chessBoardSide):
    chessBoard.insert(rowIndex, [])
    content = rowStart
    for columnIndex in range(0, chessBoardSide):
        chessBoard[rowIndex].insert(columnIndex, content)
        content = 1 if content == 0 else 0

    rowStart = 1 if rowStart == 0 else 0

for row in chessBoard:
    for cell in row:
        print(cell, end=" ")
    print()
