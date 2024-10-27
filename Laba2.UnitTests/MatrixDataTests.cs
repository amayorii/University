namespace Laba2.UnitTests;

public class MatrixDataTests
{
    MyMatrix mtx = new(new double[5, 4]);

    [Fact]
    public void StringCtors_NotRectangular_ThrowsExc()
    {
        Assert.ThrowsAny<Exception>(() => new MyMatrix(""));
        //4\t5\t6\t7\n6\t65\t5\t4\n5\t6\t7\t8\n6\t5\t4\t2
    }

    [Fact]
    public void JaggedCtor_NotRectangular_ThrowsExc()
    {
        Assert.ThrowsAny<Exception>(() => new MyMatrix([[4134, 432], [4314, 5525, 523]]));
    }

    [Fact]
    public void Parameters_Equal_ShouldEqual()
    {
        Assert.Equal((5, 4), (mtx.Height, mtx.Width));
    }

    [Fact]
    public void Parameters_NotEqual_ShouldNotEqual()
    {
        Assert.NotEqual((7, 9), (mtx.Height, mtx.Width));
    }

    [Fact]
    public void Getters_ValidValuesAndIndexes_ShouldEqual()
    {
        Assert.Equal((5, 4, 0, 0), (mtx.GetHeight(), mtx.GetWidth(), mtx.GetMatrixElement(3, 2), mtx[2, 1]));
    }

    [Fact]
    public void Getters_InvalidIndexes_ThrowsExc()
    {
        Assert.ThrowsAny<IndexOutOfRangeException>(() => mtx.GetMatrixElement(3, 199));
        Assert.ThrowsAny<IndexOutOfRangeException>(() => mtx.GetMatrixElement(-3, 199));
        Assert.ThrowsAny<IndexOutOfRangeException>(() => mtx.GetMatrixElement(3, -199));
        Assert.ThrowsAny<IndexOutOfRangeException>(() => mtx[66, 5]);
        Assert.ThrowsAny<IndexOutOfRangeException>(() => mtx[-66, 5]);
        Assert.ThrowsAny<IndexOutOfRangeException>(() => mtx[66, -5]);
    }

    [Fact]
    public void Setters_ValidValuesAndIndexes_ShouldEqual()
    {
        mtx.SetMatrixElement(3, 3, 100);
        mtx[2, 2] = 101;
        Assert.Equal((5, 4, 100, 101), (mtx.GetHeight(), mtx.GetWidth(), mtx[3, 3], mtx[2, 2]));
    }

    [Fact]
    public void Setters_InvalidIndexes_ThrowsExc()
    {
        Assert.ThrowsAny<IndexOutOfRangeException>(() => mtx.SetMatrixElement(7, 8, 100));
        Assert.ThrowsAny<IndexOutOfRangeException>(() => mtx.SetMatrixElement(-7, 8, 100));
        Assert.ThrowsAny<IndexOutOfRangeException>(() => mtx.SetMatrixElement(7, -8, 100));
        Assert.ThrowsAny<IndexOutOfRangeException>(() => mtx[9, 10] = 101);
        Assert.ThrowsAny<IndexOutOfRangeException>(() => mtx[-9, 10] = 101);
        Assert.ThrowsAny<IndexOutOfRangeException>(() => mtx[9, -10] = 101);
    }

    [Fact]
    public void ConvertFromStrArrToMatrix_ContainsLetter_ThrowsExc()
    {
        Assert.ThrowsAny<Exception>(() => new MyMatrix("4\t5\t6\t7\n6\t65\t5\t4\nigga\t6\t7\t8\n6\t5\t4\t2"));
    }

    [Fact]
    public void ToString_SameMatrix_ShouldEqual()
    {
        Assert.Equal("4\t5\t6\t7\n6\t65\t5\t4\n12\t6\t7\t8\n6\t5\t4\t2", new MyMatrix("4\t5\t6\t7\n6\t65\t5\t4\n12\t6\t7\t8\n6\t5\t4\t2").ToString());
    }

    [Fact]
    public void ToString_WrongMatrix_ShouldNotEqual()
    {
        Assert.NotEqual("0\t1\t2\t3\n4\t5\t6\t7\n8\t9\t10\t11\n12\t13\t14\t15", new MyMatrix("4\t5\t6\t7\n6\t65\t5\t4\n12\t6\t7\t8\n6\t5\t4\t2").ToString());
    }

    [Fact]
    public void PlusOverload_EquivalentMatrix_ShouldEqual()
    {
        MyMatrix mtx1 = new("4\t5\t6\t7\n6\t30\t-10\t4\n6\t6\t7\t8\n6\t5\t4\t2");
        MyMatrix mtx2 = new("4\t5\t6\t5\n3\t30\t5\t4\n6\t6\t7\t8\n6\t5\t4\t2");
        MyMatrix mtx3 = new("8\t10\t12\t12\n9\t60\t-5\t8\n12\t12\t14\t16\n12\t10\t8\t4");
        Assert.Equal(mtx3.ToString(), (mtx1 + mtx2).ToString());
    }

    [Fact]
    public void PlusOverload_WrongMatrix_ShouldNotEqual()
    {
        MyMatrix mtx1 = new("4\t5\t6\t7\n6\t30\t-10\t4\n6\t6\t7\t8\n6\t5\t4\t2");
        MyMatrix mtx2 = new("4\t5\t6\t5\n3\t30\t5\t4\n6\t6\t7\t8\n6\t5\t4\t2");
        MyMatrix mtx3 = new("3\t1\t12\t-10\n5\t74\t-2\t1\n5\t0\t9\t76\n92\t-13\t3\t4");
        Assert.NotEqual(mtx3.ToString(), (mtx1 + mtx2).ToString());
    }

    [Fact]
    public void MultiplyOverload_EquivalentMatrix_ShouldEqual()
    {
        MyMatrix mtx1 = new("4\t5\t6\t7\n6\t30\t-10\t4\n6\t6\t7\t8\n6\t5\t4\t2");
        MyMatrix mtx2 = new("4\t5\t6\t5\n3\t30\t5\t4\n6\t6\t7\t8\n6\t5\t4\t2");
        MyMatrix mtx3 = new("109\t241\t119\t102\n78\t890\t132\t78\n132\t292\t147\t126\n75\t214\t97\t86");
        Assert.Equal(mtx3.ToString(), (mtx1 * mtx2).ToString());
    }

    [Fact]
    public void MultiplyOverload_WrongMatrix_ShouldNotEqual()
    {
        MyMatrix mtx1 = new("4\t5\t6\t7\n6\t30\t-10\t4\n6\t6\t7\t8\n6\t5\t4\t2");
        MyMatrix mtx2 = new("4\t5\t6\t5\n3\t30\t5\t4\n6\t6\t7\t8\n6\t5\t4\t2");
        MyMatrix mtx3 = new("3\t1\t12\t-10\n5\t74\t-2\t1\n5\t0\t9\t76\n92\t-13\t3\t4");
        Assert.NotEqual(mtx3.ToString(), (mtx1 * mtx2).ToString());
    }

    [Fact]
    public void GetTransponedCopy_TransponedMatrix_ShouldEqual()
    {
        MyMatrix mtx1 = new("1\t2\t3\t4\n5\t6\t7\t8\n9\t10\t11\t12\n13\t14\t15\t16");
        MyMatrix mtx2 = new("1\t5\t9\t13\n2\t6\t10\t14\n3\t7\t11\t15\n4\t8\t12\t16");
        mtx1 = mtx1.GetTransponedCopy();
        Assert.Equal(mtx1.ToString(), mtx2.ToString());
    }

    [Fact]
    public void GetTransponedCopy_WrongMatrix_ShouldNotEqual()
    {
        MyMatrix mtx1 = new("1\t2\t3\t4\n5\t6\t7\t8\n9\t10\t11\t12\n13\t14\t15\t16");
        MyMatrix mtx2 = new("0\t0\t0\t0\n1\t5\t17\t14\n3\t7\t1531\t85\n4\t8\t152\t16");
        mtx1 = mtx1.GetTransponedCopy();
        Assert.NotEqual(mtx1.ToString(), mtx2.ToString());
    }

    [Fact]
    public void TransponeMe_TransponedMatrix_ShouldEqual()
    {
        MyMatrix mtx1 = new("1\t2\t3\t4\n5\t6\t7\t8\n9\t10\t11\t12\n13\t14\t15\t16");
        MyMatrix mtx2 = new("1\t5\t9\t13\n2\t6\t10\t14\n3\t7\t11\t15\n4\t8\t12\t16");
        mtx1.TransponeMe();
        Assert.Equal(mtx1.ToString(), mtx2.ToString());
    }

    [Fact]
    public void TransponeMe_WrongMatrix_ShouldNotEqual()
    {
        MyMatrix mtx1 = new("1\t2\t3\t4\n5\t6\t7\t8\n9\t10\t11\t12\n13\t14\t15\t16");
        MyMatrix mtx2 = new("0\t0\t0\t0\n1\t5\t17\t14\n3\t7\t1531\t85\n4\t8\t152\t16");
        mtx1.TransponeMe();
        Assert.NotEqual(mtx1.ToString(), mtx2.ToString());
    }
}