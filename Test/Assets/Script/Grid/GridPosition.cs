// struct is value type , between Class is refrence type
// Which is mean Struct send a copy , classe the actual value refrernce




public struct GridPosition 
{
    public int x;
    public int z;

    public GridPosition(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public override string ToString() // is proper text presentation ,we can override it to get some cutome behaviour
    {
        return $"x: {x}; z: {z}";
        // it is the same of "x: " + x + "; x: " + z ; 
    }
}