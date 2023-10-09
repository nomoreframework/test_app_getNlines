using System.Text;

namespace _1;
public class Class1
{
    private readonly char delimiter;
    private readonly int bufferSize;
    private Stream stream;
    public Class1(Stream stream,char delimiter, int size)
    {
        this.delimiter = delimiter;
        this.bufferSize = size;
        this.stream = stream;
    }
    public async ValueTask<char[]> ReadAsync(){
        char[] result;
            using (StreamReader SourceStream = new StreamReader(stream,Encoding.UTF8, false, bufferSize, true))
            {
                result = new char[bufferSize];
                await SourceStream.ReadAsync(result, 0, bufferSize);
            }
           return result;
    }
    public string Read(){
        if(stream is null)  
            throw new ArgumentNullException(nameof(stream));
        using (var reader = new StreamReader(stream, Encoding.UTF8, false, bufferSize, true))
        {
            StringBuilder messageBuilder = new();
            char[] buffer = new char[bufferSize];
            int bytesRead;

            while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
            {
                for (int i = 0; i < bytesRead; i++)
                {
                    if (buffer[i] == delimiter) return messageBuilder.ToString();
                    messageBuilder.Append(buffer[i]);
                }
            }
            return messageBuilder.ToString();
        }
    }
}

