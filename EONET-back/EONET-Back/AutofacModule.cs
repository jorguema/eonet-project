using Autofac;
using Eonet.Services;
using Eonet.Services.Interfaces;

namespace EONET_Back
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventService>().As<IEventService>();
        }
    }
}
