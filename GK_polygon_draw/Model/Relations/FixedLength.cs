namespace GK_polygon_draw.Model.Relations
{
    public class FixedLength
    {
        public Relation<float> LengthRelation { get; set; }

        public FixedLength(float length)
        {
            LengthRelation = new Relation<float>(length);
        }
        public float GetLength()
        {
            return LengthRelation.Constraint;
        }

        public override string ToString()
        {
            return "Fixed Length: " + LengthRelation.Constraint.ToString();
        }
    }
}
