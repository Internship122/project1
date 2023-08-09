namespace WebApplication1.GraphQl
{
    public class FileInputType : InputObjectType<FileInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<FileInput> descriptor)
        {
            descriptor.Name("FileInput");
            descriptor.Field(f => f.File).Type<NonNullType<UploadType>>();
        }
    }
}
