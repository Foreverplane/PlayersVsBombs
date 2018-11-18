using System.Collections.Generic;

public interface IResourceProvider
{
    T GetResourceView<T>() where T : View;
    IEnumerable<T> GetResourceViews<T>() where T: View;
}