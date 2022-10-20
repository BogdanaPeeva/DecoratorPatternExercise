namespace PhoneDemo;

public abstract class Phone
{
    public virtual string Type() => GetType().Name;
    public abstract string Model();
    public abstract string FullName();
    public abstract decimal GetPrice();
}

public class Samsung : Phone
{
    public override string Model() => "s22";

    public override string FullName() => $" {this.Type()} {this.Model()}";

    public override decimal GetPrice() => 2000m;

}

public class Xiaomi : Phone
{
    public override string Model() => "Mi10";

    public override string FullName() => $" {this.Type()} {this.Model()}";

    public override decimal GetPrice() => 1000m;

}

public abstract class PhoneExtra : Phone
{
    protected Phone component;

    protected PhoneExtra(Phone component)
    {
        this.component = component;
    }

    public override string Type() => this.component.Type();

    public override string Model() => this.component.Model();

    public override string FullName() => $" {this.Type()} {this.component.Model()}";

    public override decimal GetPrice() => this.component.GetPrice();

}

public class WithHigherResolutionCamera : PhoneExtra
{
    public WithHigherResolutionCamera(Phone component) : base(component)
    {

    }

    public override string Model() => base.Model() + " plus";

    public override string FullName() => $" {this.Type()} {this.Model()}";

    public override decimal GetPrice()
    {
        if (this.Type() == "Samsung")
        {
            return base.GetPrice() + 200m;

        }
        else if (this.Type() == "Xiaomi")
        {
            return base.GetPrice() + 173m;

        }

        return 0;
    }
}

public class With250GB : PhoneExtra
{
    public With250GB(Phone component) : base(component)
    {

    }

    public override string Model() => base.Model() + " 250GB";

    public override string FullName() => $" {this.Type()} {this.Model()}";

    public override decimal GetPrice() => base.GetPrice() + 300m;

}

public class MainClass
{
    public static void Main()
    {

        Phone phone = new Samsung();

        //Phone phone = new Xiaomi();

        PhoneExtra phoneWithHigherResolution = new WithHigherResolutionCamera(phone);

        PhoneExtra phoneWith250gb = new With250GB(phone);

        PhoneExtra phoneWithHigherResolutionAnd250gb = new WithHigherResolutionCamera(new With250GB(phone));


        Console.WriteLine("Phone Model:" + phone.FullName());

        Console.WriteLine("Total Price: " + phone.GetPrice() + "lv.");

        Console.WriteLine();

        Console.WriteLine("Phone Model:" + phoneWithHigherResolution.FullName());

        Console.WriteLine("Total Price: " + phoneWithHigherResolution.GetPrice() + "lv.");

        Console.WriteLine();

        Console.WriteLine("Phone Model:" + phoneWith250gb.FullName());

        Console.WriteLine("Total Price: " + phoneWith250gb.GetPrice() + "lv.");

        Console.WriteLine();

        Console.WriteLine("Phone Model:" + phoneWithHigherResolutionAnd250gb.FullName());

        Console.WriteLine("Total Price: " + phoneWithHigherResolutionAnd250gb.GetPrice() + "lv.");



    }
}

