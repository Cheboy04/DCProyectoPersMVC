using Microsoft.EntityFrameworkCore;
using DCProyectoPersMVC.Models;
using DC_ProyectoPers_API.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace DC_ProyectoPers_API.Controllers;

public static class DCBebidaEndpoints
{
    public static void MapDCBebidaEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/DCBebida").WithTags(nameof(DCBebida));

        group.MapGet("/", async (DC_ProyectoPers_APIContext db) =>
        {
            return await db.DCBebida.ToListAsync();
        })
        .WithName("GetAllDCBebida")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<DCBebida>, NotFound>> (int dc_bebidaid, DC_ProyectoPers_APIContext db) =>
        {
            return await db.DCBebida.AsNoTracking()
                .FirstOrDefaultAsync(model => model.DC_BebidaID == dc_bebidaid)
                is DCBebida model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetDCBebidaById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int dc_bebidaid, DCBebida dCBebida, DC_ProyectoPers_APIContext db) =>
        {
            var affected = await db.DCBebida
                .Where(model => model.DC_BebidaID == dc_bebidaid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.DC_BebidaID, dCBebida.DC_BebidaID)
                    .SetProperty(m => m.DC_Nombre, dCBebida.DC_Nombre)
                    .SetProperty(m => m.DC_Precio, dCBebida.DC_Precio)
                    .SetProperty(m => m.DC_Tipo, dCBebida.DC_Tipo)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateDCBebida")
        .WithOpenApi();

        group.MapPost("/", async (DCBebida dCBebida, DC_ProyectoPers_APIContext db) =>
        {
            db.DCBebida.Add(dCBebida);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/DCBebida/{dCBebida.DC_BebidaID}",dCBebida);
        })
        .WithName("CreateDCBebida")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int dc_bebidaid, DC_ProyectoPers_APIContext db) =>
        {
            var affected = await db.DCBebida
                .Where(model => model.DC_BebidaID == dc_bebidaid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteDCBebida")
        .WithOpenApi();
    }
}
