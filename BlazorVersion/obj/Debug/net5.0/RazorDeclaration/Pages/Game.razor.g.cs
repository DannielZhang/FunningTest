// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/dannielzhang/Projects/BlazorApp/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/dannielzhang/Projects/BlazorApp/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/dannielzhang/Projects/BlazorApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/dannielzhang/Projects/BlazorApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/dannielzhang/Projects/BlazorApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/dannielzhang/Projects/BlazorApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/dannielzhang/Projects/BlazorApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/dannielzhang/Projects/BlazorApp/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/dannielzhang/Projects/BlazorApp/_Imports.razor"
using BlazorApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/dannielzhang/Projects/BlazorApp/_Imports.razor"
using BlazorApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/dannielzhang/Projects/BlazorApp/_Imports.razor"
using Blazor.Extensions.Canvas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/dannielzhang/Projects/BlazorApp/Pages/Game.razor"
using BlazorApp.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/dannielzhang/Projects/BlazorApp/Pages/Game.razor"
using System.Drawing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/dannielzhang/Projects/BlazorApp/Pages/Game.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/dannielzhang/Projects/BlazorApp/Pages/Game.razor"
using Blazor.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/dannielzhang/Projects/BlazorApp/Pages/Game.razor"
using Blazor.Extensions.Canvas.Canvas2D;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/dannielzhang/Projects/BlazorApp/Pages/Game.razor"
using BootstrapBlazor.Components;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/game")]
    public partial class Game : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 30 "/Users/dannielzhang/Projects/BlazorApp/Pages/Game.razor"
      

    private Canvas2DContext _context;

    protected BECanvasComponent _canvasReference;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        this._context = await this._canvasReference.CreateCanvas2DAsync();
        //await this._context.SetFillStyleAsync("green");

        //await this._context.FillRectAsync(10, 100, 100, 100);

        // 构建三个行包围盒
        int height = 80;
        int padding_y = 15;

        //放置物件包围盒
        int part_x = 10;
        int part_y = 65;

        for (int i = 0; i < 3; i++)
        {
            int outterRect_y = 15 + (height + padding_y) * i;

            await this._context.SetFillStyleAsync("gray");
            await this._context.FillRectAsync(10, outterRect_y, 600, height);

            for (int j = 0; j < 3 + i * 2; j++)
            {
                await this._context.SetFillStyleAsync("red");
                await this._context.FillRectAsync(30 + j * (part_x + 10), outterRect_y + 10, part_x, part_y);
            }
        }
    }


    // canvas events:
    double begin_x, begin_y, end_x, end_y;
    List<Point> path;

    protected async Task canvasMouseDown(MouseEventArgs args)
    {
        begin_x = args.OffsetX;
        begin_y = args.OffsetY;

        //创建新path2D
        await this._context.BeginPathAsync();
        await this._context.MoveToAsync(begin_x, begin_y);

    }

    protected async Task canvasMouseMove(MouseEventArgs args)
    {
        await this._context.MoveToAsync(args.OffsetX, args.OffsetY);
    }

    protected async Task canvasMouseUp(MouseEventArgs args)
    {
        end_x = args.OffsetX;
        end_y = args.OffsetY;

        // 生成闭合路线
        await this._context.MoveToAsync(end_x, end_y);
        await this._context.LineToAsync(begin_x, begin_y);
        await this._context.ClosePathAsync();
        await this._context.StrokeAsync();
    }

    [Inject]
    private DialogService? dialogService { get; set; }

    protected Task player1BtnClick() => dialogService.Show(new DialogOption()
    {
        Title = "我是服务创建的弹出框",
        BodyTemplate = BootstrapDynamicComponent.CreateComponent<Button>(new KeyValuePair<string, object>[]
            {
                new(nameof(Button.ChildContent), new RenderFragment(builder => builder.AddContent(0, "我是服务创建的按钮")))
            })
            .Render()
    });

    protected Task player2BtnClick() => dialogService.Show(new DialogOption()
    {

    });




#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private WeatherForecastService testService { get; set; }
    }
}
#pragma warning restore 1591