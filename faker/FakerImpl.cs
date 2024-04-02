
namespace faker {

    public class FakerImpl : IFaker
    {
        private readonly FakerConfigImpl? globalConfig;

        public FakerImpl() => globalConfig = null;

        public FakerImpl(FakerConfigImpl globalConfig) => this.globalConfig = globalConfig;

        public T create<T>()
        {
            var type = typeof(T);
            var localConfig = globalConfig == null ? null : globalConfig.getConfigForType(type);
            var obj = Generators.generateDto(type, localConfig);
            return (T)obj;
        }

    }

}