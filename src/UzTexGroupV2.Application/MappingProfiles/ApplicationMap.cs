using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Application.MappingProfiles;

internal static class ApplicationMap
{
    internal static Applications MapToApplication(CreateApplicationDto createApplicationDto)
    {
        return new Applications
        {
            Id = Guid.NewGuid(),
            FirstName = createApplicationDto.firstName,
            LastName = createApplicationDto.lastName,
            Email = createApplicationDto.email,
            PhoneNumber = createApplicationDto.phoneNumber,
            ApplicationMessage = createApplicationDto.applicationMassage,
            JobId = createApplicationDto.jobId
        };
    }
    internal static ApplicationDto MapToApplicationDto(Applications applications)
    {
        return new ApplicationDto
        (
            id: applications.Id,
            firstName: applications.FirstName,
            lastName: applications.LastName,
            email: applications.Email,
            applicationMassage: applications.ApplicationMessage,
            phoneNumber: applications.PhoneNumber,
            job: applications.Job is not null ? JobMap.MapToJobDto(applications.Job) : null,
            addressDto : applications.Job is not null ? AddressMap.MapToAddressDto(applications.Address) : null
       ); 
    }

    internal static void MapToApplication(
        Applications applications,
        ModifyApplicationDto modifyApplicationDto)
    {
        applications.FirstName = modifyApplicationDto.firstName ?? applications.FirstName;
        applications.LastName = modifyApplicationDto.lastName ?? applications.LastName;
        applications.PhoneNumber = modifyApplicationDto.phoneNumber ?? applications.PhoneNumber;
        applications.ApplicationMessage = modifyApplicationDto.applicationMassage ?? applications.ApplicationMessage;
        applications.JobId = modifyApplicationDto.jobId ?? applications.JobId;

    }
}
