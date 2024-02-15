## Object design of LinkedIn Profiles

```
public class Profile
{
  public string? Name { get; set; }

  public string? Email { get; set; }
  public List<Experience> experiences { get; }
  public List<Skill> skills { get; }

  public Profile()
  {
    this.experiences = new List<Experience>();
    this.skills = new List<Skill>();
  }

  public void addExperience(Experience e)
  {
    experiences.Add(e);
  }
}

public class Experience
{
  public string? Designation { get; set; }

  public string? Company { get; set; }

}

public class Skill
{

}

public class Program
{
  public static void Main()
  {
    Profile p1 = new Profile { Name = "John", Email = "john@example.com" };
    Experience e1 = new Experience
    {
      Designation = "Software Engineer",
      Company = "Google"
    };
    Experience e2 = new Experience
    {
      Designation = "Senior Software Engineer",
      Company = "Tesla"
    };
    p1.addExperience(e1);
    p1.addExperience(e2);
    // Get me all the designations of the person, p
    foreach (var designation in p1.experiences.Select(e => e.Designation))
    {
      Console.WriteLine(designation);
    }
    Profile p2 = new Profile { Name = "George", Email = "george@example.com" };
    p2.addExperience(new Experience
    {
      Designation = "Software Engineer",
      Company = "Tesla"
    });
    p2.addExperience(new Experience
    {
      Designation = "ML Engineer",
      Company = "OpenAI"
    });
    var profileList = new List<Profile> { p1, p2 };
    // Given the profileList,
    // get me the designations of the person with email "george@example.com"
    foreach (var designation in profileList
    .FirstOrDefault(p => p.Email == "george@example.com")?
    .experiences
    .Select(e => e.Designation))
    {
      Console.WriteLine(designation);
    }
  }
}
```
