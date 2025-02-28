namespace Box2D;

/// <summary>
/// Optional restitution mixing callback. This intentionally provides no context objects because this is called
/// from a worker thread.
/// </summary>
/// <param name="restitutionA">The restitution A</param>
/// <param name="materialA">The material A</param>
/// <param name="restitutionB">The restitution B</param>
/// <param name="materialB">The material B</param>
/// <returns>The mixed restitution</returns>
public delegate float RestitutionCallback(float restitutionA, int materialA, float restitutionB, int materialB);