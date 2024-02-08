// Create/Initialize
var countrywiseParticipants = new Dictionary<string, int>()
{
  { "India", 10},
  { "US", 20},
  { "UK", 30},
};
// Key existence
Console.WriteLine($"Is India present: {countrywiseParticipants.ContainsKey("India")}");
Console.WriteLine($"Participant count from India: {countrywiseParticipants["India"]}");
// Update
countrywiseParticipants["India"] = 15;
// Remove
countrywiseParticipants.Remove("UK");
// Iterate
foreach (var cp in countrywiseParticipants)
{
    Console.WriteLine($"{cp.Key}: {cp.Value}");
}
