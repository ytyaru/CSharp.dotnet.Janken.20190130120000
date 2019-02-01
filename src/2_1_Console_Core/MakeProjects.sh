MakeProject() {
    # 1. プロジェクト作成
    ProductName=Janken
    EndpointName=${ProductName}.Console
    SlnName=${EndpointName}
    mkdir "${SlnName}"
    cd "${SlnName}"
    dotnet new sln -n "${SlnName}"
    LibName=${ProductName}
    dotnet new classlib -n "${LibName}" -f netstandard2.0
    AppName=${EndpointName}
    dotnet new console -n "${AppName}"

    # 2. ソリューションにプロジェクトを追加する
    dotnet sln add "${AppName}/${AppName}.csproj"
    dotnet sln add "${LibName}/${LibName}.csproj"

    # 3. プロジェクトの参照を設定する
    cd ${AppName}
    dotnet add reference "../${LibName}/${LibName}.csproj"
    cd ..
}
RunTest() {
    # 4. 実行
#    dotnet test "${TestName}/${TestName}.csproj"
    cd "${AppName}"
    dotnet run
    cd ..
}
Build() {
    dotnet restore
    dotnet publish -r linux-arm
    "${AppName}/bin/Debug/netcoreapp2.2/linux-arm/${AppName}"
}
echo "========== Make projects =========="
time MakeProject
echo "========== Run =========="
time RunTest
echo "========== Build =========="
time Build

