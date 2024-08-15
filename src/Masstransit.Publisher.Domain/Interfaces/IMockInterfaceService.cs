using Masstransit.Publisher.Domain.Classes;

namespace Masstransit.Publisher.Domain.Interfaces
{
    public interface IMockInterfaceService
    {
        object Mock(Type type, MockSettings? mockSettings);
        object GetMockValue(Type type, MockSettings? mockSettings);
    }
}
