using Masstransit.Publisher.Domain.Classes;

namespace Masstransit.Publisher.Domain.Interfaces
{
    public interface IMockInterfaceService
    {
        List<string> GetMockTypes();
        object Mock(Type interfaceType, List<MockSettings>? mockSettings);
    }
}
