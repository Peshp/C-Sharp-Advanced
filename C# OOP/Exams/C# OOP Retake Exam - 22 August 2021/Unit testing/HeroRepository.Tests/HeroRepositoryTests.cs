using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{  
    [Test]
    public void ConstructorShouldWorkProperlyWithData()
    {
        HeroRepository heroList = new HeroRepository();
        Assert.AreEqual(0, heroList.Heroes.Count);
    }
    [Test]
    public void CreateShouldWorkProperly()
    {
        HeroRepository heroList = new HeroRepository();
        heroList.Create(new Hero("h1", 10));
        Assert.AreEqual(1, heroList.Heroes.Count);      
    }
    [Test]
    public void CreateShouldReturnCorrectMessage()
    {
        HeroRepository heroList = new HeroRepository();
        string output = $"Successfully added hero h1 with level 10";
        Assert.AreEqual(output, heroList.Create(new Hero("h1", 10)));
    }
    [Test]
    public void CreateShouldThrowsExceptionWhenHeroIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new HeroRepository().Create(null));
    }
    [Test]
    public void CreateShouldThrowsExceptionWhenNameIsAlreadyExist()
    {
        HeroRepository heroList = new HeroRepository();
        heroList.Create(new Hero("h1", 10));
        Assert.Throws<InvalidOperationException>(() => heroList.Create(new Hero("h1", 15)));
    }
    [Test]
    public void RemoveShouldWorkProperly()
    {
        HeroRepository heroList = new HeroRepository();
        heroList.Create(new Hero("h1", 10));
        heroList.Create(new Hero("h2", 15));
        heroList.Remove("h1");
        Assert.AreEqual(1, heroList.Heroes.Count);
    }
    [Test]
    public void RemoveShouldReturnTrueWhenDeleteHeroProperly()
    {
        HeroRepository heroList = new HeroRepository();
        heroList.Create(new Hero("h1", 10));
        heroList.Create(new Hero("h2", 15));
        Assert.AreEqual(true, heroList.Remove("h1"));
    }
    [Test]
    public void RemoveShouldThrowsAnEsceptionWhenHeroIsNullOrWhiteSpace()
    {
        Assert.Throws<ArgumentNullException>(() => new HeroRepository().Remove(null));
    }
    [Test]
    public void GetHeroWithHighestLevelShouldWorkProperly()
    {
        HeroRepository heroList = new HeroRepository();
        heroList.Create(new Hero("h1", 10));
        Hero hero = new Hero("h2", 20);
        heroList.Create(hero);
        Assert.AreEqual(hero, heroList.GetHeroWithHighestLevel());
    }
    [Test]
    public void GetHeroShouldWorkProperly()
    {
        HeroRepository heroList = new HeroRepository();
        heroList.Create(new Hero("h1", 10));
        Hero hero = new Hero("h2", 20);
        heroList.Create(hero);
        Assert.AreEqual(hero, heroList.GetHero("h2"));
    }
}