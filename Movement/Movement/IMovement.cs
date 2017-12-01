namespace Movement
{
    public interface IMovement
    {
        void SetMaxYPosition(int maxPosition);
        void SetMaxXPosition(int maxPosition);
        int GetNewXPosition(int oldXPosition);
        int GetNewYPosition(int oldYPosition);
    }
}