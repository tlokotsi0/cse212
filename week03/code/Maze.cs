/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Returns the current position as a string, formatted as "Current location (x, y)"
    /// </summary>
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }

    /// <summary>
    /// Move left if possible. Otherwise, throw InvalidOperationException.
    /// Index 0 = Left
    /// </summary>
    public void MoveLeft()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out var moves) && moves[0])
        {
            _currX--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Move right if possible. Otherwise, throw InvalidOperationException.
    /// Index 1 = Right
    /// </summary>
    public void MoveRight()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out var moves) && moves[1])
        {
            _currX++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Move up if possible. Otherwise, throw InvalidOperationException.
    /// Index 2 = Up
    /// </summary>
    public void MoveUp()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out var moves) && moves[2])
        {
            _currY--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Move down if possible. Otherwise, throw InvalidOperationException.
    /// Index 3 = Down
    /// </summary>
    public void MoveDown()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out var moves) && moves[3])
        {
            _currY++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }
}