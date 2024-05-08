
using System;
using System.Collections;
using System.Runtime;
using Mosa.FileSystem.FAT;
using Mosa.Kernel.BareMetal;
using Mosa.Runtime.Plug;

using WebAssembly;
using WebAssembly.Instructions;
using WebAssembly.Runtime;

namespace DescriptorKernel.Core;

public abstract class Sample {
    public abstract int Demo(int value);
}

public static class Wasm {
    static void LoadWasm() {
        // Program.RootFileSystem
        var wasmFile = Program.RootFileSystem.FindEntry("TEST.WASM");
        var wasmStream = new FatFileStream(Program.RootFileSystem, wasmFile);

        // var imports = new ImportDictionary {
        //     { "env", "sayc", new FunctionImport(new Action<int>(raw=>Console.Write((char)raw))) },
        // };

        // var compiled = Compile.FromBinary<dynamic>(wasmStream)(imports);
        // compiled.Exports.main();
    }
}
