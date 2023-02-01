// struct is value type , between Class is refrence type
// Which is mean Struct send a copy , classe the actual value refrernce


using System;

public struct GridPosition :  IEquatable<GridPosition>
{
    public int x;
    public int z;

    public GridPosition(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    
    
    //from the system
    // interfaced
    public bool Equals(GridPosition other)
    {
        return this == other;
    }

    public override bool Equals(object obj)
    {
        return obj is GridPosition position &&
               x == position.x &&
               z == position.z;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);


    }
    



    public override string ToString() // is proper text presentation ,we can override it to get some cutome behaviour
    {
        return $"x: {x}; z: {z}";
        // it is the same of "x: " + x + "; x: " + z ; 
    }
    
    public static bool operator ==( GridPosition a, GridPosition b) // because it's struct we do this
    {
        return a.x == b.x && a.z == b.z;


    }

    public static bool operator !=(GridPosition a, GridPosition b) 
    {

        return !(a == b);

    }
    
    
    
}