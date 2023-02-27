using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Application.MappingProfiles;

internal static class JobMap
{
    internal static Job MapToJob(CreateJobDto createJobDto)
    {
        return new Job
        {
            Id = createJobDto.Id ?? Guid.NewGuid(),
            Name = createJobDto.Name,
            Desription = createJobDto.Desription,
            Salary = createJobDto.Salary,
            WorkTime = createJobDto.WorkTime,
            FactoryId = createJobDto.FactoryId
        };
    }
    internal static JobDto MapToJobDto(Job job)
    {
        return new JobDto
        (
            id :job.Id,
            name : job.Name,
            description : job.Desription,
            salary : job.Salary,
            workTime : job.WorkTime,
            factoryDto : job.Factory is not null ? FactoryMap.MapToFactoryDto(job.Factory) : null
        );
    }

    internal static void MapToJob(Job job, ModifyJobDto modifyJobDto)
    {
        job.Name = modifyJobDto.Name ?? job.Name;
        job.Salary = modifyJobDto.Salary ?? job.Salary;
        job.Desription = modifyJobDto.Desription ?? job.Desription;
        job.FactoryId = modifyJobDto.FactoryId ?? job.FactoryId;
        job.WorkTime = modifyJobDto.WorkTime ?? job.WorkTime;
    }
}
