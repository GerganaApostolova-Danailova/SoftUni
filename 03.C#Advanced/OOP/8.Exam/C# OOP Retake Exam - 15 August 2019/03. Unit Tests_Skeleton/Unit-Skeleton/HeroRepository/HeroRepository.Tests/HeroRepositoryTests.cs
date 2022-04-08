using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository heroRepository;

    private Hero hero;

    [SetUp]
    public void Setup()
    {
        heroRepository = new HeroRepository();

        hero = new Hero("Gosho", 20);
    }

    [Test]
    public void TestConstructor()
    {
        Assert.IsNotNull(heroRepository.Heroes);
    }

    [Test]
    public void TestConstructorOfHeroWorkCorrectly()
    {
        Assert.AreEqual("Gosho",hero.Name);
        Assert.AreEqual(20, hero.Level);
    }

    [Test]
    public void CallMethodShoudWorkCorrectly()
    {
        string output = "Successfully added hero Gosho with level 20";

        Assert.AreEqual(output, heroRepository.Create(hero));
    }

    [Test]
    public void CreateMethodShoudHaveExeptionWhenHeroIsNull()
    {
        Hero hero2 = null;

        Assert.Throws<ArgumentNullException>(()=> heroRepository.Create(hero2));
    }

    [Test]
    public void CreateMethodShoudHaveExeptionWhenHeroNameAreAlreadyExist()
    {
        heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero));
    }
    
    [Test]
    public void RemuveMethodShoudWorckCorrectly()
    {
        heroRepository.Create(hero);

        Assert.AreEqual(true, heroRepository.Remove("Gosho"));
    }

    [Test]
    public void RemuveMethodShoudWorckCorrectlyWhithFalse()
    {
        heroRepository.Create(hero);

        Assert.AreEqual(false, heroRepository.Remove("Pesho"));
    }

    [Test]
    public void RemuveMethodShoudThrowExeptionWhenNameIsNull()
    {
        Hero hero2 = new Hero("", 20);
        heroRepository.Create(hero2);

        Assert.Throws<ArgumentNullException>(()=> heroRepository.Remove(""));
    }

    [Test]
    public void RemuveMethodShoudThrowExeptionWhenNameIsWhiteSpace()
    {
        Hero hero2 = new Hero("     ", 20);
        heroRepository.Create(hero2);

        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove("      "));
    }

    //public Hero GetHero(string name)
    //{
    //    Hero hero = this.data.FirstOrDefault(h => h.Name == name);
    //    return hero;
    //}

    [Test]
    public void TestMethodForGetHeroWhitHithestName()
    {
        Hero hero2 = new Hero("Ginka", 30);
        heroRepository.Create(hero);
        heroRepository.Create(hero2);

        Assert.AreEqual(hero2, heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void TestMethodForGetHeroWorkCorrectly()
    {
        heroRepository.Create(hero);
        
        Assert.AreEqual(hero, heroRepository.GetHero("Gosho"));
    }

}