namespace Timesheet.Test;
public class ProjectServiceTest {
   
    private readonly Mock<IProjectDB> _projectDBMock = new Mock<IProjectDB>();

    private ProjectService? _projectService;
    [Test]
    public void ReturnPositiveResponseWhenProjectIsDeleted()
    {
        // Arrange
        List<Entry> entries = new List<Entry>(){
            new Entry(1, DateTime.Now, 8, "Comment 1"),
        };
          
        _projectDBMock.Setup(_projectDBMock => _projectDBMock.GetProject(1)).Returns(new ProjectDetails("Project 1", "Description 1", 1, entries));
        _projectDBMock.Setup(_projectDBMock => _projectDBMock.DeleteEntry(1, 1)).Returns(true);
        _projectDBMock.Setup(_projectDBMock => _projectDBMock.DeleteProject(1)).Returns(true);

        _projectService = new ProjectService(_projectDBMock.Object);


        // Act
        int code = _projectService.DeleteProject(1);


        // Assert
        Assert.That(code, Is.EqualTo(202));
    }
}