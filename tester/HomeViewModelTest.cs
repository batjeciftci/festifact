using System;
using festifact.models.Dtos.Festival;
using Moq;
using System.Collections.ObjectModel;

namespace tester
{
	public class HomeViewModelTest
	{
        [Fact]
        public async Task GetFestivals_ValidNetworkAccess_AddsFestivalsToCollection()
        {
            // Arrange
            var festivalServiceMock = new Mock<IFestivalService>();
            festivalServiceMock.Setup(service => service.GetFestivals())
                .ReturnsAsync(new ObservableCollection<FestivalDto>()
                {
                    new FestivalDto() { Title = "Festival 1" },
                    new FestivalDto() { Title = "Festival 2" }
                });

            var viewModel = new HomeViewModel(festivalServiceMock.Object);

            // Act
            await viewModel.GetFestivals();

            // Assert
            Assert.Equal(2, viewModel.Festivals.Count);
            Assert.Equal("Festival 1", viewModel.Festivals[0].Title);
            Assert.Equal("Festival 2", viewModel.Festivals[1].Title);
        }
    }
}

