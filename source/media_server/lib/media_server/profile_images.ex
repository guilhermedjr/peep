defmodule MediaServer.ProfileImages do
  @moduledoc """
  The ProfileImages context.
  """

  import Ecto.Query, warn: false
  alias MediaServer.Repo

  alias MediaServer.ProfileImages.ProfileImage

  @doc """
  Returns the list of profile_image.

  ## Examples

      iex> list_profile_image()
      [%ProfileImage{}, ...]

  """
  def list_profile_image do
    Repo.all(ProfileImage)
  end

  @doc """
  Gets a single profile_image.

  Raises `Ecto.NoResultsError` if the Profile image does not exist.

  ## Examples

      iex> get_profile_image!(123)
      %ProfileImage{}

      iex> get_profile_image!(456)
      ** (Ecto.NoResultsError)

  """
  def get_profile_image!(id), do: Repo.get!(ProfileImage, id)

  @doc """
  Creates a profile_image.

  ## Examples

      iex> create_profile_image(%{field: value})
      {:ok, %ProfileImage{}}

      iex> create_profile_image(%{field: bad_value})
      {:error, %Ecto.Changeset{}}

  """
  def create_profile_image(attrs \\ %{}) do
    %ProfileImage{}
    |> ProfileImage.changeset(attrs)
    |> Repo.insert()
  end

  @doc """
  Updates a profile_image.

  ## Examples

      iex> update_profile_image(profile_image, %{field: new_value})
      {:ok, %ProfileImage{}}

      iex> update_profile_image(profile_image, %{field: bad_value})
      {:error, %Ecto.Changeset{}}

  """
  def update_profile_image(%ProfileImage{} = profile_image, attrs) do
    profile_image
    |> ProfileImage.changeset(attrs)
    |> Repo.update()
  end

  @doc """
  Deletes a profile_image.

  ## Examples

      iex> delete_profile_image(profile_image)
      {:ok, %ProfileImage{}}

      iex> delete_profile_image(profile_image)
      {:error, %Ecto.Changeset{}}

  """
  def delete_profile_image(%ProfileImage{} = profile_image) do
    Repo.delete(profile_image)
  end

  @doc """
  Returns an `%Ecto.Changeset{}` for tracking profile_image changes.

  ## Examples

      iex> change_profile_image(profile_image)
      %Ecto.Changeset{data: %ProfileImage{}}

  """
  def change_profile_image(%ProfileImage{} = profile_image, attrs \\ %{}) do
    ProfileImage.changeset(profile_image, attrs)
  end
end
