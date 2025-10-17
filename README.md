# Execution Context Demo

This demo shows the usage of `ConfigureAwait()` methods and its impact in ASP.NET vs ASP.NET Core.

## 1) The problem

In ASP.NET, after the execution of an async method, some static instances like `HttpContext.Current` are `null` when `ConfigureAwait(false)`  is used.

```c#
public async Task<IEnumerable<string>> Get()
{
    HttpContext before = HttpContext.Current;

    ValuesUseCase valuesUseCase = new ValuesUseCase();
    IEnumerable<string> values = await valuesUseCase.Execute()
        .ConfigureAwait(false);

    HttpContext after = HttpContext.Current; // this is null

    return values;
}
```

ASP.NET Core does not have this problem because it provides those instances as properties on the controller.

### ASP.NET (Presentation Layer)

The `HttpContext.Current` is a static instance needed to be unique for each executed action. This is part of the ASP.NET context being automatically restored after the execution of an async method. But, if `ConfigureAwait(false)` is used, the context is not restored and the `HttpContext.Current` instance remains `null`.

This is not a problem if, after the execution of the async method there is no need to access those static instances.

### Business Layer

At the business level, on the other hand, it is a good practice to call `ConfigureAwait(false)` to avoid the performance penalty involved in saving/restoring context because there isn't one to restore.

## 2) Solution Content

The solution contains two folders with projects:

### `Net`

A demo using .NET and ASP.NET Core

- `ExecutionContextDemo.NetCore` - The main Web API project.
- `ExecutionContextDemo.NetCore.Business` - Business logic

### `NetFramework`

A demo using .NET Framework and ASP.NET

- `ExecutionContextDemo` - The main Web API project
- `ExecutionContextDemo.Business` - Business logic

## 3) How To Use

Put a breakpoint in the `DummyController` and compare the `before` and `after` instances when `ConfigureAwait(false)` is used or not.