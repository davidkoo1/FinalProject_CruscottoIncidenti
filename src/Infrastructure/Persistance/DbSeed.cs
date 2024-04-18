using Domain.Entities;
using Domain.Entities.HelpDesk;

namespace Infrastructure.Persistance
{
    public class DbSeed
    {
        #region Roles
        public static readonly Role AdminRole = new Role { Id = 1, Name = "Admin", Description = "User that can add, modify and disable other users, change data manually." };
        public static readonly Role OperatorRole = new Role { Id = 2, Name = "Operator", Description = "User that can import data from a CSV file." };
        public static readonly Role UserRole = new Role { Id = 3, Name = "User", Description = "User that can can view information about incidents." };
        #endregion

        #region Users
        public static readonly User Admin = new User
        {
            Id = 1,
            UserName = "cr00001",
            Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
            FullName = "Admin",
            Email = "admin@mail.com",
            IsEnabled = true,
        };
        public static readonly User MainUserAdmin = new User
        {
            Id = 2,
            UserName = "Crme145",
            Password = "e17c8fa0a351caf1138741f0862208a250ecfa122ce3f4cbba637a2e510e2920",
            FullName = "David Alexandr",
            Email = "alexander.david@gmail.com",
            IsEnabled = true,
        };
        #endregion

        #region UserRole
        public static readonly UserRole RoleAdmin = new UserRole { UserId = Admin.Id, RoleId = AdminRole.Id };
        public static readonly UserRole RoleMainAdmin = new UserRole { UserId = MainUserAdmin.Id, RoleId = AdminRole.Id };

        #endregion

        #region Origin
        public static readonly IncidentOrigin Aplication = new IncidentOrigin { Id = 1, Name = "Application" };
        public static readonly IncidentOrigin External = new IncidentOrigin { Id = 2, Name = "External" };
        public static readonly IncidentOrigin Infrastructure = new IncidentOrigin { Id = 3, Name = "Infrastructure" };
        #endregion

        #region Ambit
        public static readonly IncidentAmbit Software = new IncidentAmbit { Id = 1, Name = "Software" };
        public static readonly IncidentAmbit Functionality = new IncidentAmbit { Id = 2, Name = "Functionality" };
        public static readonly IncidentAmbit Phase = new IncidentAmbit { Id = 3, Name = "Phase" };
        public static readonly IncidentAmbit Release = new IncidentAmbit { Id = 4, Name = "Release" };
        public static readonly IncidentAmbit Service = new IncidentAmbit { Id = 5, Name = "Service" };
        public static readonly IncidentAmbit TransmissionChannels = new IncidentAmbit { Id = 6, Name = "Transmission Channels" };
        public static readonly IncidentAmbit CICS = new IncidentAmbit { Id = 7, Name = "CICS" };
        public static readonly IncidentAmbit Database = new IncidentAmbit { Id = 8, Name = "Database" };
        public static readonly IncidentAmbit HardwareHost = new IncidentAmbit { Id = 9, Name = "Hardware Host" };
        public static readonly IncidentAmbit HardwareOpen = new IncidentAmbit { Id = 10, Name = "Hardware Open" };
        public static readonly IncidentAmbit Middleware = new IncidentAmbit { Id = 11, Name = "Middleware" };
        public static readonly IncidentAmbit Networks = new IncidentAmbit { Id = 12, Name = "Networks" };
        public static readonly IncidentAmbit Security = new IncidentAmbit { Id = 13, Name = "Security" };
        public static readonly IncidentAmbit BasicHostSoftware = new IncidentAmbit { Id = 14, Name = "Basic Host Software" };
        public static readonly IncidentAmbit OpenBasicSoftware = new IncidentAmbit { Id = 15, Name = "Open Basic Software" };
        public static readonly IncidentAmbit ServiceSoftware = new IncidentAmbit { Id = 16, Name = "Service Software" };
        public static readonly IncidentAmbit Storage = new IncidentAmbit { Id = 17, Name = "Storage" };
        #endregion

        #region IncidentType
        public static readonly IncidentType Configuration = new IncidentType { Id = 1, Name = "Configuration" };
        public static readonly IncidentType SoftwareMalfunction = new IncidentType { Id = 2, Name = "Software Malfunction" };
        public static readonly IncidentType ThirdParts = new IncidentType { Id = 3, Name = "Third Parts" };
        public static readonly IncidentType IncorrectChange = new IncidentType { Id = 4, Name = "Incorrect Change" };
        public static readonly IncidentType Code = new IncidentType { Id = 5, Name = "Code" };
        public static readonly IncidentType ResourceSaturation = new IncidentType { Id = 6, Name = "Resource Saturation" };
        public static readonly IncidentType InsufficientResources = new IncidentType { Id = 7, Name = "Insufficient Resources" };
        public static readonly IncidentType HardwareMalfunction = new IncidentType { Id = 8, Name = "Hardware Malfunction" };
        public static readonly IncidentType Degradation = new IncidentType { Id = 9, Name = "Degradation" };
        public static readonly IncidentType Block = new IncidentType { Id = 10, Name = "Block" };
        public static readonly IncidentType Accesses = new IncidentType { Id = 11, Name = "Accesses" };
        public static readonly IncidentType CyberAttacks = new IncidentType { Id = 12, Name = "Cyber Attacks" };
        public static readonly IncidentType Certificates = new IncidentType { Id = 13, Name = "Certificates" };
        public static readonly IncidentType Firewall = new IncidentType { Id = 14, Name = "Firewall" };
        public static readonly IncidentType IDM = new IncidentType { Id = 15, Name = "IDM" };
        public static readonly IncidentType Patching = new IncidentType { Id = 16, Name = "Patching" };
        #endregion

        #region OriginsToAmbit
        public static readonly OriginsToAmbit OriginsToAmbit1 = new OriginsToAmbit { OriginId = Aplication.Id, AmbitId = Phase.Id };
        public static readonly OriginsToAmbit OriginsToAmbit2 = new OriginsToAmbit { OriginId = Aplication.Id, AmbitId = Functionality.Id };
        public static readonly OriginsToAmbit OriginsToAmbit3 = new OriginsToAmbit { OriginId = Aplication.Id, AmbitId = Release.Id };
        public static readonly OriginsToAmbit OriginsToAmbit4 = new OriginsToAmbit { OriginId = Aplication.Id, AmbitId = Software.Id };

        public static readonly OriginsToAmbit OriginsToAmbit5 = new OriginsToAmbit { OriginId = External.Id, AmbitId = Functionality.Id };
        public static readonly OriginsToAmbit OriginsToAmbit6 = new OriginsToAmbit { OriginId = External.Id, AmbitId = Service.Id };
        public static readonly OriginsToAmbit OriginsToAmbit7 = new OriginsToAmbit { OriginId = External.Id, AmbitId = Software.Id };

        public static readonly OriginsToAmbit OriginsToAmbit8 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = TransmissionChannels.Id };
        public static readonly OriginsToAmbit OriginsToAmbit9 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = CICS.Id };
        public static readonly OriginsToAmbit OriginsToAmbit10 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = Database.Id };
        public static readonly OriginsToAmbit OriginsToAmbit11 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = Phase.Id };
        public static readonly OriginsToAmbit OriginsToAmbit12 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = HardwareHost.Id };
        public static readonly OriginsToAmbit OriginsToAmbit13 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = HardwareOpen.Id };
        public static readonly OriginsToAmbit OriginsToAmbit14 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = Middleware.Id };
        public static readonly OriginsToAmbit OriginsToAmbit15 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = Networks.Id };
        public static readonly OriginsToAmbit OriginsToAmbit16 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = Security.Id };
        public static readonly OriginsToAmbit OriginsToAmbit17 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = Software.Id };
        public static readonly OriginsToAmbit OriginsToAmbit18 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = BasicHostSoftware.Id };
        public static readonly OriginsToAmbit OriginsToAmbit19 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = OpenBasicSoftware.Id };
        public static readonly OriginsToAmbit OriginsToAmbit20 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = ServiceSoftware.Id };
        public static readonly OriginsToAmbit OriginsToAmbit21 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = Storage.Id };
        #endregion

        #region AmbitsToTypes
        public static readonly AmbitsToTypes AmbitsToTypes1 = new AmbitsToTypes { AmbitId = Phase.Id, TypeId = Configuration.Id };
        public static readonly AmbitsToTypes AmbitsToTypes2 = new AmbitsToTypes { AmbitId = Phase.Id, TypeId = SoftwareMalfunction.Id };

        public static readonly AmbitsToTypes AmbitsToTypes3 = new AmbitsToTypes { AmbitId = Functionality.Id, TypeId = SoftwareMalfunction.Id };
        public static readonly AmbitsToTypes AmbitsToTypes4 = new AmbitsToTypes { AmbitId = Functionality.Id, TypeId = ThirdParts.Id };

        public static readonly AmbitsToTypes AmbitsToTypes5 = new AmbitsToTypes { AmbitId = Release.Id, TypeId = IncorrectChange.Id };

        public static readonly AmbitsToTypes AmbitsToTypes6 = new AmbitsToTypes { AmbitId = Software.Id, TypeId = IncorrectChange.Id };
        public static readonly AmbitsToTypes AmbitsToTypes7 = new AmbitsToTypes { AmbitId = Software.Id, TypeId = Code.Id };
        public static readonly AmbitsToTypes AmbitsToTypes8 = new AmbitsToTypes { AmbitId = Software.Id, TypeId = Configuration.Id };
        public static readonly AmbitsToTypes AmbitsToTypes9 = new AmbitsToTypes { AmbitId = Software.Id, TypeId = ResourceSaturation.Id };
        public static readonly AmbitsToTypes AmbitsToTypes10 = new AmbitsToTypes { AmbitId = Software.Id, TypeId = ThirdParts.Id };
        public static readonly AmbitsToTypes AmbitsToTypes11 = new AmbitsToTypes { AmbitId = Software.Id, TypeId = InsufficientResources.Id };

        public static readonly AmbitsToTypes AmbitsToTypes12 = new AmbitsToTypes { AmbitId = Service.Id, TypeId = ThirdParts.Id };

        public static readonly AmbitsToTypes AmbitsToTypes13 = new AmbitsToTypes { AmbitId = TransmissionChannels.Id, TypeId = SoftwareMalfunction.Id };
        public static readonly AmbitsToTypes AmbitsToTypes14 = new AmbitsToTypes { AmbitId = TransmissionChannels.Id, TypeId = InsufficientResources.Id };
        public static readonly AmbitsToTypes AmbitsToTypes15 = new AmbitsToTypes { AmbitId = TransmissionChannels.Id, TypeId = Configuration.Id };

        public static readonly AmbitsToTypes AmbitsToTypes16 = new AmbitsToTypes { AmbitId = CICS.Id, TypeId = HardwareMalfunction.Id };
        public static readonly AmbitsToTypes AmbitsToTypes17 = new AmbitsToTypes { AmbitId = CICS.Id, TypeId = Configuration.Id };

        public static readonly AmbitsToTypes AmbitsToTypes18 = new AmbitsToTypes { AmbitId = Database.Id, TypeId = Degradation.Id };
        public static readonly AmbitsToTypes AmbitsToTypes19 = new AmbitsToTypes { AmbitId = Database.Id, TypeId = HardwareMalfunction.Id };
        public static readonly AmbitsToTypes AmbitsToTypes20 = new AmbitsToTypes { AmbitId = Database.Id, TypeId = SoftwareMalfunction.Id };
        public static readonly AmbitsToTypes AmbitsToTypes21 = new AmbitsToTypes { AmbitId = Database.Id, TypeId = InsufficientResources.Id };

        public static readonly AmbitsToTypes AmbitsToTypes22 = new AmbitsToTypes { AmbitId = HardwareHost.Id, TypeId = InsufficientResources.Id };
        public static readonly AmbitsToTypes AmbitsToTypes23 = new AmbitsToTypes { AmbitId = HardwareHost.Id, TypeId = ResourceSaturation.Id };

        public static readonly AmbitsToTypes AmbitsToTypes24 = new AmbitsToTypes { AmbitId = HardwareOpen.Id, TypeId = IncorrectChange.Id };
        public static readonly AmbitsToTypes AmbitsToTypes25 = new AmbitsToTypes { AmbitId = HardwareOpen.Id, TypeId = Block.Id };
        public static readonly AmbitsToTypes AmbitsToTypes26 = new AmbitsToTypes { AmbitId = HardwareOpen.Id, TypeId = Degradation.Id };
        public static readonly AmbitsToTypes AmbitsToTypes27 = new AmbitsToTypes { AmbitId = HardwareOpen.Id, TypeId = InsufficientResources.Id };

        public static readonly AmbitsToTypes AmbitsToTypes28 = new AmbitsToTypes { AmbitId = Middleware.Id, TypeId = IncorrectChange.Id };
        public static readonly AmbitsToTypes AmbitsToTypes29 = new AmbitsToTypes { AmbitId = Middleware.Id, TypeId = SoftwareMalfunction.Id };
        public static readonly AmbitsToTypes AmbitsToTypes30 = new AmbitsToTypes { AmbitId = Middleware.Id, TypeId = InsufficientResources.Id };
        public static readonly AmbitsToTypes AmbitsToTypes31 = new AmbitsToTypes { AmbitId = Middleware.Id, TypeId = ResourceSaturation.Id };

        public static readonly AmbitsToTypes AmbitsToTypes32 = new AmbitsToTypes { AmbitId = Networks.Id, TypeId = IncorrectChange.Id };

        public static readonly AmbitsToTypes AmbitsToTypes33 = new AmbitsToTypes { AmbitId = Security.Id, TypeId = Accesses.Id };
        public static readonly AmbitsToTypes AmbitsToTypes34 = new AmbitsToTypes { AmbitId = Security.Id, TypeId = CyberAttacks.Id };
        public static readonly AmbitsToTypes AmbitsToTypes35 = new AmbitsToTypes { AmbitId = Security.Id, TypeId = Certificates.Id };
        public static readonly AmbitsToTypes AmbitsToTypes36 = new AmbitsToTypes { AmbitId = Security.Id, TypeId = Configuration.Id };
        public static readonly AmbitsToTypes AmbitsToTypes37 = new AmbitsToTypes { AmbitId = Security.Id, TypeId = Firewall.Id };
        public static readonly AmbitsToTypes AmbitsToTypes38 = new AmbitsToTypes { AmbitId = Security.Id, TypeId = IDM.Id };
        public static readonly AmbitsToTypes AmbitsToTypes39 = new AmbitsToTypes { AmbitId = Security.Id, TypeId = Patching.Id };

        public static readonly AmbitsToTypes AmbitsToTypes40 = new AmbitsToTypes { AmbitId = BasicHostSoftware.Id, TypeId = InsufficientResources.Id };

        public static readonly AmbitsToTypes AmbitsToTypes41 = new AmbitsToTypes { AmbitId = OpenBasicSoftware.Id, TypeId = InsufficientResources.Id };
        public static readonly AmbitsToTypes AmbitsToTypes42 = new AmbitsToTypes { AmbitId = OpenBasicSoftware.Id, TypeId = ResourceSaturation.Id };

        public static readonly AmbitsToTypes AmbitsToTypes43 = new AmbitsToTypes { AmbitId = ServiceSoftware.Id, TypeId = Block.Id };
        public static readonly AmbitsToTypes AmbitsToTypes44 = new AmbitsToTypes { AmbitId = ServiceSoftware.Id, TypeId = Degradation.Id };
        public static readonly AmbitsToTypes AmbitsToTypes45 = new AmbitsToTypes { AmbitId = ServiceSoftware.Id, TypeId = ResourceSaturation.Id };

        public static readonly AmbitsToTypes AmbitsToTypes46 = new AmbitsToTypes { AmbitId = Storage.Id, TypeId = ResourceSaturation.Id };
        #endregion

        #region Scenary
        public static readonly Scenary ScenaryA1 = new Scenary { Id = 1, Name = "A1" };
        public static readonly Scenary ScenaryA2 = new Scenary { Id = 2, Name = "A2" };
        public static readonly Scenary ScenaryA3 = new Scenary { Id = 3, Name = "A3" };
        #endregion

        #region Threat
        public static readonly Threat ThreatAA1 = new Threat { Id = 1, Name = "AA1" };
        public static readonly Threat ThreatAA2 = new Threat { Id = 2, Name = "AA2" };
        public static readonly Threat ThreatAA3 = new Threat { Id = 3, Name = "AA3" };
        #endregion

        #region Incident
        public static readonly Incident Incident1 = new Incident
        {
            Id = 1,
            CreatedBy = 1,
            Created = DateTime.UtcNow,
            RequestNr = "1",
            Subsystem = "Te",
            OpenDate = DateTime.UtcNow,
            Type = "Configuration",
            ApplicationType = "str",
            Urgency = "No",
            SubCause = "tmp",
            ProblemDescription = "Descr",
            ProblemSummary = "Summ",
            Solution = "str",
            IsDeleted = false,
            IncidentTypeId = 1,
            AmbitId = 1,
            OriginId = 1,
            ThirdParty = "tmps",
            ScenaryId = 1,
            ThreatId = 1
        };
        #endregion
    }
}
