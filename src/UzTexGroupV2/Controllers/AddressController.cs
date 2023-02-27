using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.EntitiesDto.Addresses;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;
using UzTexGroupV2.Model;

namespace UzTexGroupV2.Controllers;

[Route("/{langCode}/[controller]")]
[ApiController]
public class AddressController : LocalizedControllerBase
{
    private readonly AddressService addressService;
    public AddressController(LocalizedUnitOfWork localizedUnitOfWork,
        AddressService addressService) : base(localizedUnitOfWork)
    {
        this.addressService = addressService;
    }
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async ValueTask<ActionResult<AddressDto>> PostAddressAsync(
        CreateAddressDto createAddressDto)
    {
        var createdAddress = await this.addressService
            .CreateAddressAsync(createAddressDto);

        return Created("", createdAddress);
    }

    [AllowAnonymous]
    [HttpGet("id: Guid")]
    public async ValueTask<ActionResult<AddressDto>> GetAddressByIdAsync(
        Guid id)
    {
        var address = await this.addressService
            .RetrieveAddressByIdAsync(id); 

        return Ok(address);
    }

    [AllowAnonymous]
    [HttpGet]
    public async ValueTask<IActionResult> GetallAddressesAsync(
      [FromQuery] QueryParameter queryParameter)
    {
        var addresses = await this.addressService
            .RetrieveAllAdressesAsync(queryParameter);

        return Ok(addresses);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async ValueTask<ActionResult<AddressDto>> PutAddressAsync(
        [FromBody] ModifyAddressDto modifyAddressDto)
    {
        var updatedAddress = await this.addressService
            .ModifyAddressAsync(modifyAddressDto);

        return Ok(updatedAddress);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("id : Guid")]
    public async ValueTask<ActionResult<AddressDto>> DeleteAdressAsync(Guid addressId)
    {
        var deletedAdress = await this.addressService
            .DeleteAddressAsync(addressId);

        return Ok(deletedAdress);
    }
}
