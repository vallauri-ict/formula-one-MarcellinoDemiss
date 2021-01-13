ALTER TABLE[dbo].[Driver] WITH CHECK ADD CONSTRAINT [driver-ountry] FOREIGN KEY ([driverNationality])
REFERENCES [dbo].[Country] ([countryCode])
ON UPDATE CASCADE;

ALTER TABLE[dbo].[Driver] WITH CHECK ADD CONSTRAINT [FK_Teams_Countries] FOREIGN KEY ([teamCode])
REFERENCES [dbo].[Country] ([teamCode])
ON UPDATE CASCADE;